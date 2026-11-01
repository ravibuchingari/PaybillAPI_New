using System.Text;
using System.Text.Json;
using AuthenticationManager;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Paybill.Services;
using PaybillAPI.Data;
using PaybillAPI.Middlewares;
using PaybillAPI.Repositories;
using PaybillAPI.Repositories.Service;
using PaybillAPI.Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 1. Register Shared Repositories & Services
builder.Services.AddScoped<ISharedRepository, SharedRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IPartyRepository, PartyRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
builder.Services.AddScoped<IPaybillApiService, PaybillApiService>();

// 2. Database Configuration (MySQL via EF Core)
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("SqlConnection")!));

// 3. Background Service for Daily Activities
builder.Services.AddHostedService<DailyBackgroundService>();

// 4. JWT Settings & HttpContextAccessor
builder.Services.Configure<JwtTokenParameter>(builder.Configuration.GetSection("JWTSettings"));
builder.Services.AddHttpContextAccessor();

// 5. Internal HttpClient for Paybill MVC -> WebApi Integration
string apiBaseUrl = builder.Configuration["PaybillApi:BaseUrl"] ?? "http://localhost:5111/";
if (!apiBaseUrl.EndsWith('/')) apiBaseUrl += "/";
int timeoutSeconds = int.TryParse(builder.Configuration["PaybillApi:TimeoutSeconds"], out int t) ? t : 60;

builder.Services.AddHttpClient("PaybillApi", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
});

// 6. Session & Cache Configuration
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// 7. Logging (Serilog)
var logPath = Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "log", "log_.log");
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.File(
        path: logPath,
        rollingInterval: RollingInterval.Day,
        shared: true,
        outputTemplate: "{Timestamp:HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
    )
    .CreateLogger();
builder.Host.UseSerilog();

// 8. Controllers with Views (Razor Views in Areas/Paybill + API Controllers in Areas/WebApi)
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

builder.Services.AddEndpointsApiExplorer();

// 9. CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var origins = builder.Configuration.GetSection("CORS-Settings:Allow-Origins").Get<string[]>() ?? ["http://localhost:4200"];
        var methods = builder.Configuration.GetSection("CORS-Settings:Allow-Methods").Get<string[]>() ?? ["OPTIONS", "GET", "HEAD", "POST", "PUT", "DELETE"];
        var headers = builder.Configuration.GetSection("CORS-Settings:Allow-Headers").Get<string[]>() ?? ["SecurityKey", "Bearer", "Authorization", "X-Requested-With"];
        policy.WithOrigins(origins).WithMethods(methods).WithHeaders(headers).AllowCredentials();
    });
});

// 10. Dual Authentication: JWT Bearer (for /api/*) + Cookie Authentication (for /Paybill/* MVC)
const string SmartAuthScheme = "SmartAuthScheme";
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = SmartAuthScheme;
        options.DefaultChallengeScheme = SmartAuthScheme;
    })
    .AddPolicyScheme(SmartAuthScheme, "JWT Bearer or Cookie", options =>
    {
        options.ForwardDefaultSelector = context =>
        {
            if (context.Request.Path.StartsWithSegments("/api") ||
                context.Request.Headers.Authorization.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                return JwtBearerDefaults.AuthenticationScheme;
            }
            return CookieAuthenticationDefaults.AuthenticationScheme;
        };
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "PayBill.Web.Auth";
        options.Cookie.HttpOnly = true;
        options.LoginPath = "/Paybill/Account/Login";
        options.LogoutPath = "/Paybill/Account/Logout";
        options.AccessDeniedPath = "/Paybill/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = Convert.ToBoolean(builder.Configuration["JWTSettings:IsValidIssuer"]),
            ValidateAudience = Convert.ToBoolean(builder.Configuration["JWTSettings:IsValidAudience"]),
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWTSettings:ValidIssuer"]!,
            ValidAudience = builder.Configuration["JWTSettings:ValidAudience"]!,
            ClockSkew = TimeSpan.FromMinutes(1),
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:JWTKey"]!))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = _ => Task.CompletedTask
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// 11. Automatic Database Schema Verification on Startup
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
        if (await dbContext.Database.CanConnectAsync())
        {
            await DatabaseSchemaMigrator.EnsureSchemaUpToDateAsync(dbContext);
        }
    }
    catch (Exception ex)
    {
        Log.Warning(ex, "Could not run automatic schema migration on startup.");
    }
}

// 12. HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Paybill/Dashboard/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseGlobalExceptionMiddleware();
app.UseCookiePolicy();

// 13. Endpoint & Area Routing
// Attribute-routed WebApi controllers: /api/[controller]/...
app.MapControllers();

// Paybill MVC Area route: /Paybill/{controller}/{action}/{id?}
app.MapAreaControllerRoute(
    name: "paybill_area",
    areaName: "Paybill",
    pattern: "Paybill/{controller=Dashboard}/{action=Index}/{id?}");

// Generic Areas route
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

// Default root fallback route -> routes to Paybill MVC Area (Account/Login)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}",
    defaults: new { area = "Paybill" });

app.Run();
