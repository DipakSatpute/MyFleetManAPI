using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Infrastructure.Contracts
{
    public interface IJwtTokenRepository
    {
        Task<(string token, DateTime expires)> CreateTokenAsync(AspNetUser user, IList<string> roles);
    }
}
