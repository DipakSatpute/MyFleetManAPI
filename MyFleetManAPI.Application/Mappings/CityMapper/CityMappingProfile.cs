
using AutoMapper;
using MyFleetManAPI.Application.DTOs.CityMaster;
using MyFleetManAPI.Application.DTOs.Employee;
using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.Mappings.CityMapper
{
    public class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<CreateCityDto, TblCitymaster>();

            CreateMap<TblCitymaster,UpdateCityDto>();
        }
    }
}
