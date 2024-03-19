using System.Text;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NetWars.Repositories.Identity;
using NetWars.Repositories.Identity.Contracts;
using NetWars.Repositories.Units;
using NetWars.Repositories.Units.Contracts;
using NetWars.Logic.Identity;
using NetWars.Logic.Identity.Contracts;
using NetWars.Logic.Units;
using NetWars.Logic.Units.Contracts;
using NetWars.Logic.Url;
using NetWars.Logic.Url.Contracts;
using NetWars.Repositories.Units.Mappers;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

//Logic
builder.Services.AddSingleton<ITokenLogic, TokenLogic>();
builder.Services.AddSingleton<IUnitLogic, UnitLogic>();
builder.Services.AddSingleton<IUrlLogic, UrlLogic>();
builder.Services.AddSingleton<IUserLogic, UserLogic>();
builder.Services.AddSingleton<IWeaponLogic, WeaponLogic>();

//Repos
builder.Services.AddSingleton<IUnitRepository, UnitRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IWeaponRepository, WeaponRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(bearer =>
{
    bearer.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "NetWars API - V1", Version = "v1" });
    swagger.SwaggerDoc("v2", new OpenApiInfo { Title = "NetWars API - V2", Version = "v2" });
});

DapperExtensions.DapperExtensions.SetMappingAssemblies(
    new[]
    {
        typeof(UnitMapper).Assembly,
        typeof(WeaponMapper).Assembly
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swagger =>
    {
        swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "NetWars API - V1");
        swagger.SwaggerEndpoint("/swagger/v2/swagger.json", "NetWars API - V2");
    });
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
