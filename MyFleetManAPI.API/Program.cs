using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFleetManAPI.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyFleetManDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ClickToCallDB")));

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyFleetManDbContext>()
    .AddDefaultTokenProviders();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


