using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFleetManAPI.Application.Contracts;
using MyFleetManAPI.Application.DTOs.Login;
using MyFleetManAPI.Common.Responses;

namespace MyFleetManAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _loginService.LoginAsync(dto);
            return Ok(new ApiResponse<LoginResponseDto>
            {
                statusCode = 200,
                Data = result
            });
        }
    }
}
