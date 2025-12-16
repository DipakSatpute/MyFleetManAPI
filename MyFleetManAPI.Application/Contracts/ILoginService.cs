using MyFleetManAPI.Application.DTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.Contracts
{
    public interface ILoginService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto dto);
    }
}
