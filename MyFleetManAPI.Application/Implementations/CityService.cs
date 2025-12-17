using AutoMapper;
using MyFleetManAPI.Application.Contracts;
using MyFleetManAPI.Application.DTOs.CityMaster;
using MyFleetManAPI.Infrastructure.Contracts;
using MyFleetManAPI.Infrastructure.Implementations;
using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.Implementations
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        public CityService(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }
        public async Task<UpdateCityDto> CreateAsync(CreateCityDto dto)
        {
            var city = _mapper.Map<TblCitymaster>(dto);
            var savedEntity = await _cityRepository.AddAsync(city);
            var result = _mapper.Map<UpdateCityDto>(savedEntity);
            return result;
        }

        public async Task<List<UpdateCityDto>> GetAllCityAsync()
        {
            var cityEntity = await _cityRepository.GetAllCityAsync();
            var result = _mapper.Map<List<UpdateCityDto>>(cityEntity);
            return result;

        }
        public async Task<UpdateCityDto> UpdateCityAsync(UpdateCityDto dto)
        {
            var existingEntity = await _cityRepository.GetCityByIdAsync(dto.CityId);
            if (existingEntity == null)
            {
                return null;
            }

            _mapper.Map(dto, existingEntity);
            var updatedEntity = await _cityRepository.UpdateCityAsync(existingEntity);
            var result = _mapper.Map<UpdateCityDto>(updatedEntity);
            return result;

        }
        public async Task<UpdateCityDto?> GetCityByIdAsync(int cityId)
        {
            var entity = await _cityRepository.GetCityByIdAsync(cityId);
            return entity == null ? null : _mapper.Map<UpdateCityDto>(entity);
           
        }

    }
}
