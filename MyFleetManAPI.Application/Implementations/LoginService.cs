using Microsoft.AspNetCore.Identity;
using MyFleetManAPI.Application.Contracts;
using MyFleetManAPI.Application.DTOs.Login;
using MyFleetManAPI.Infrastructure.Contracts;
using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly IJwtTokenRepository _jwtTokenRepository;
        private readonly IAuthRepository _iAuthRepository;

        public LoginService(UserManager<AspNetUser> userManager, IJwtTokenRepository jwtTokenRepository, IAuthRepository iAuthRepository)
        {
            _userManager = userManager;
            _jwtTokenRepository = jwtTokenRepository;
            _iAuthRepository = iAuthRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
        {
            string message = string.Empty;
            // Check user exists
            var user = await _iAuthRepository.GetByUserNameAsync(dto.UserName);
            if (user == null)
            {
                message = "Invalid username or password";
                return new LoginResponseDto
                {
                    Token = string.Empty,
                    Expires = DateTime.MinValue,
                    Message = message
                };
            }

            // Validate password using SignInManager
            var result = await _iAuthRepository.CheckPasswordAsync(user, dto.Password);

            if (!result)
            {
                message = "Invalid password";
                return new LoginResponseDto
                {
                    Token = string.Empty,
                    Expires = DateTime.MinValue,
                    Message = message
                };
            }  

            // Get roles
            var roles = await _iAuthRepository.GetRolesAsync(user);

            // Generate JWT
            var (token, expires) = await _jwtTokenRepository.CreateTokenAsync(user, roles);

            return new LoginResponseDto
            {
                Token = token,
                Expires = expires,
                Message = message

            };
        }
    }
}
