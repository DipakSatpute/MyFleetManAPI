using Microsoft.AspNetCore.Identity;
using MyFleetManAPI.Infrastructure.Contracts;
using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Infrastructure.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly IJwtTokenRepository _jwtTokenRepository;

        public AuthRepository(UserManager<AspNetUser> userManager,IJwtTokenRepository jwtTokenRepository)
        {
            _userManager = userManager;
            _jwtTokenRepository = jwtTokenRepository;
        }

        public Task<AspNetUser?> GetByUserNameAsync(string username) => _userManager.FindByNameAsync(username);
        public Task<IList<string>> GetRolesAsync(AspNetUser user) => _userManager.GetRolesAsync(user);
        public async Task<bool> CheckPasswordAsync(AspNetUser user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

    }
}
