using AutoMapper;
using MyFleetManAPI.Application.DTOs.Employee;
using MyFleetManAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyFleetManAPI.Application.Mappings.EmployeeMapper
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();

            CreateMap<Employee, UpdateEmployeeDto>();
            CreateMap<UpdateEmployeeDto, Employee>();
            
        }
    }
}
