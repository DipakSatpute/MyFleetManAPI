using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyFleetManAPI.Common.Constants;
using MyFleetManAPI.Infrastructure.Contracts;
using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Infrastructure.Implementations
{
    public class JwtTokenRepository : IJwtTokenRepository
    {
        private readonly JwtSettings _settings;


        public JwtTokenRepository(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
        }

        public Task<(string token, DateTime expires)> CreateTokenAsync(AspNetUser user, IList<string> roles)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                         {
                         new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                         new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? string.Empty),
                         new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty)
                         };


            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));


            var expires = DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);


            var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: creds
            );


            var compact = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult((compact, expires));
        }
    }
}
