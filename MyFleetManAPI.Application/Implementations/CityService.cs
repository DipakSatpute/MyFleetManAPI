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
    public class CityService :ICityService
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
            // STEP 1: Map DTO → Domain Entity
            var city = _mapper.Map<TblCitymaster>(dto);

            // STEP 2: Call Infrastructure Repository (returns Entity)
            var savedEntity = await _cityRepository.AddAsync(city);

            // STEP 3: Map Domain Entity → DTO
            var result = _mapper.Map<UpdateCityDto>(savedEntity);

            return result;

        }
    }
}
