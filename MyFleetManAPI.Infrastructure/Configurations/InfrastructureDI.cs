using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFleetManAPI.Common.Constants;
using MyFleetManAPI.Infrastructure.Contracts;
using MyFleetManAPI.Infrastructure.Data;
using MyFleetManAPI.Infrastructure.Identity;
using MyFleetManAPI.Infrastructure.Implementations;
using MyFleetManAPI.Infrastructure.Model;

namespace MyFleetManAPI.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<MyFleetManIdentityDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("ClickToCallDB")));

            services.AddDbContext<MyFleetManDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("ClickToCallDB")));

            services.AddIdentity<AspNetUser, IdentityRole<Guid>>(options => { })
                     .AddEntityFrameworkStores<MyFleetManIdentityDbContext>()
                     .AddDefaultTokenProviders();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IJwtTokenRepository, JwtTokenRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            return services;
        }
    }
}
