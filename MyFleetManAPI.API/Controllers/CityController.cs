using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFleetManAPI.Application.Contracts;
using MyFleetManAPI.Application.DTOs;
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

        [HttpPost("create_city")]
        public async Task<ResponseDto> CreateCity([FromBody] CreateCityDto cityDto)
        {
            ResponseDto response = new ResponseDto();
            var createdCity = await _cityService.CreateAsync(cityDto);
            if (createdCity != null && createdCity.CityId > 0)
            {
                response.StatusCode = StatusCodes.Status200OK;
                response.StatusMessage = "City created successfully.";
                response.Data = createdCity;
            }
            else
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.StatusMessage = "Failed to create city.";
                response.Data = cityDto;
            }
            return response;
        }
        [HttpGet("get_all_city")]
        public async Task<ResponseDto> GetAllCity()
        {
            ResponseDto response = new ResponseDto();
            var cityList = await _cityService.GetAllCityAsync();
            if (cityList != null && cityList.Count > 0)
            {
                response.StatusCode = StatusCodes.Status200OK;
                response.StatusMessage = "City list retrieved successfully.";
                response.Data = cityList;
            }
            else
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.StatusMessage = "No cities found.";
                response.Data = null;
            }
            return response;
        }
        [HttpPost("update_city")]
        public async Task<ResponseDto> UpdateCity([FromBody] UpdateCityDto cityDto)
        {
            ResponseDto response = new ResponseDto();
            if (cityDto != null)
            {
                var result = await _cityService.UpdateCityAsync(cityDto);
                if (result != null)
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.StatusMessage = "City updated successfully.";
                    response.Data = result;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.StatusMessage = "Failed to update city.";
                    response.Data = cityDto;
                }
            }
            else
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.StatusMessage = "Model is null.";
                response.Data = cityDto;
            }
            return response;
        }
        [HttpPost("get_city_by_id/{city_id}")]
        public async Task<ResponseDto> GetCityById(int city_id)
        {
            ResponseDto response = new ResponseDto();
            var city = await _cityService.GetCityByIdAsync(city_id);
            if (city != null)
            {
                response.StatusCode = StatusCodes.Status200OK;
                response.StatusMessage = "City retrieved successfully.";
                response.Data = city;
            }
            else
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.StatusMessage = "City not found.";
                response.Data = null;
            }
            return response;
        }
    }
}
