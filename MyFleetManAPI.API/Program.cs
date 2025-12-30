using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFleetManAPI.API.Extensions;
using MyFleetManAPI.DataAccess.Data;
using MyFleetManAPI.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// Register Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


