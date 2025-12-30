using Microsoft.AspNetCore.Identity;
using MyFleetManAPI.Common.Enums;

namespace MyFleetManAPI.API.Extensions
{
    public static class SeedRoles
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
            {
                string roleName = role.ToString();

                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    
    }
}
