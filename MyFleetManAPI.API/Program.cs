using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using MyFleetManAPI.API.Extensions;
using MyFleetManAPI.DataAccess.Data;
using MyFleetManAPI.Infrastructure.Configurations;
using Serilog;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Add infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// Register Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddRateLimiter(options =>
//{
//    options.AddFixedWindowLimiter("login", opt =>
//    {
//        opt.Window = TimeSpan.FromMinutes(1);
//        opt.PermitLimit = 5;
//        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//        opt.QueueLimit = 0;
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
        c.RoutePrefix = string.Empty; // <--- THIS MAKES SWAGGER DEFAULT PAGE
        c.InjectStylesheet("/swagger-custom.css");
    });
}

//using (var scope = app.Services.CreateScope())
//{
//    await AdminSeeder.SeedAdminUserAsync(scope.ServiceProvider);
//}
using (var scope = app.Services.CreateScope())
{
    await SeedRoles.SeedAsync(scope.ServiceProvider);
}


app.UseAuthentication();
app.UseAuthorization();
//app.UseRateLimiter();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


