using MyFleetManAPI.Application.DTOs.CityMaster;
using MyFleetManAPI.Application.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.Contracts
{
    public interface ICityService
    {
        Task<UpdateCityDto> CreateAsync(CreateCityDto dto);
        Task<List<UpdateCityDto>> GetAllCityAsync();
        Task<UpdateCityDto> UpdateCityAsync(UpdateCityDto dto);
        Task<UpdateCityDto?> GetCityByIdAsync(int cityId);

    }
}
