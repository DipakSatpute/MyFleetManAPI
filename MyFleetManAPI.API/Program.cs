using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyFleetManAPI.API.Extensions;
using MyFleetManAPI.Application.Contracts;
using MyFleetManAPI.Application.Implementations;
using MyFleetManAPI.Common.Constants;
using MyFleetManAPI.Infrastructure;
using MyFleetManAPI.Infrastructure.Data;
using MyFleetManAPI.Infrastructure.Identity;
using MyFleetManAPI.Infrastructure.Model;
using System.Text;
using AutoMapper;



var builder = WebApplication.CreateBuilder(args);

// Add infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();

// JWT Authentication
var jwt = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
if (jwt == null || string.IsNullOrEmpty(jwt.Secret))
{
    throw new InvalidOperationException("JwtSettings or JwtSettings.Secret is not configured.");
}
var key = Encoding.UTF8.GetBytes(jwt.Secret);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Register Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add application-level services
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICityService, CityService>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
