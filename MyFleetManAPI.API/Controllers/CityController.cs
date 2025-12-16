using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFleetManAPI.Application.Contracts;
using MyFleetManAPI.Application.DTOs.CityMaster;

namespace MyFleetManAPI.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityDto cityDto)
        {
            var createdCity = await _cityService.CreateAsync(cityDto);
            return Ok(createdCity);
        }
    }
}
