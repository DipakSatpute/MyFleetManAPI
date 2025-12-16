using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Infrastructure.Contracts
{
    public interface IAuthRepository
    {
        Task<AspNetUser?> GetByUserNameAsync(string username);
        Task<bool> CheckPasswordAsync(AspNetUser user, string password);
        Task<IList<string>> GetRolesAsync(AspNetUser user);
    }
}
