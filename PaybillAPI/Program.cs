using Authentication.JWTAuthenticationManager;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.Middlewares;
using PaybillAPI.Repositories;
using PaybillAPI.Repositories.Service;
using Serilog;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var jwtParameters = new JwtTokenParameter()
{
    JwtSecurityKey = builder.Configuration["JWTSettings:JWTKey"]!,
    IsValidateIssuer = Convert.ToBoolean(builder.Configuration["JWTSettings:IsValidIssuer"]),
    IsValidateAudience = Convert.ToBoolean(builder.Configuration["JWTSettings:IsValidAudience"]),
    ValidIssuer = builder.Configuration["JWTSettings:ValidIssuer"]!,
    ValidAudience = builder.Configuration["JWTSettings:ValidAudience"]!,
    TokenValidityInMinutes = Convert.ToDouble(builder.Configuration["JWTSettings:JWTTokenValidityInMinutes"]),
};

builder.Services.AddScoped<ISharedRepository, SharedRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IPartyRepository, PartyRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

builder.Services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>(option => ActivatorUtilities.CreateInstance<JwtTokenHandler>(option, jwtParameters));
builder.Services.AddDbContext<AppDBContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("SqlConnection")!));
builder.Services.AddJwtAuthenticationExtension(jwtParameters);

builder.Services.AddHttpContextAccessor();

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
        policy.WithOrigins(builder.Configuration.GetSection("CORS-Settings:Allow-Origins")!.Get<string[]>()!)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseGlobalExceptionMiddleware();
app.MapControllers();

app.Run();
