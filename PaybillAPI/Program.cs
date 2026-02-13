using AuthenticationManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaybillAPI.Data;
using PaybillAPI.Middlewares;
using PaybillAPI.Repositories;
using PaybillAPI.Repositories.Service;
using PaybillAPI.Service;
using Serilog;
using System.Text;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

//var jwtParameters = new JwtTokenParameter()
//{
//    JwtSecurityKey = builder.Configuration["JWTSettings:JWTKey"]!,
//    IsValidateIssuer = Convert.ToBoolean(builder.Configuration["JWTSettings:IsValidIssuer"]),
//    IsValidateAudience = Convert.ToBoolean(builder.Configuration["JWTSettings:IsValidAudience"]),
//    ValidIssuer = builder.Configuration["JWTSettings:ValidIssuer"]!,
//    ValidAudience = builder.Configuration["JWTSettings:ValidAudience"]!,
//    TokenValidityInMinutes = Convert.ToDouble(builder.Configuration["JWTSettings:JWTTokenValidityInMinutes"]),
//};

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
builder.Services.AddDbContext<AppDBContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("SqlConnection")!));

//it is optional. The service is used to manage daily activities
builder.Services.AddHostedService<DailyBackgroundService>();

builder.Services.Configure<JwtTokenParameter>(builder.Configuration.GetSection("JWTSettings"));

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();

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

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger());

builder.Services.AddControllersWithViews().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var origins = builder.Configuration.GetSection("CORS-Settings:Allow-Origins").Get<string[]>();
        var methods = builder.Configuration.GetSection("CORS-Settings:Allow-Methods").Get<string[]>();
        var headers = builder.Configuration.GetSection("CORS-Settings:Allow-Headers").Get<string[]>();
        policy.WithOrigins(origins!).WithMethods(methods!).WithHeaders(headers!).AllowCredentials();
    });
});

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

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
   .AddJwtBearer(options =>
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
           OnMessageReceived = context =>
           {
               //var accessToken = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

               //if (!string.IsNullOrEmpty(accessToken))
               //{
               //    context.Token = DataProtection.DecryptWithIV(accessToken, GlobalConstants.ORG_AES_KEY_AND_IV);
               //}
               //else
               //{
               //    accessToken = context.Request.Query["access_token"];
               //    if (!string.IsNullOrEmpty(accessToken) && context.HttpContext.Request.Path.StartsWithSegments("/communicationHub"))
               //        context.Token = DataProtection.DecryptWithIV(accessToken, GlobalConstants.ORG_AES_KEY_AND_IV);
               //}

               return Task.CompletedTask;
           }
       };

   });

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
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

app.MapControllers();

app.Run();
