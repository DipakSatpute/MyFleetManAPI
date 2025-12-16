using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.DTOs.Login
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = null!;
        public DateTime Expires { get; set; }
        public string Message { get; set; } = null!;
    }
}
