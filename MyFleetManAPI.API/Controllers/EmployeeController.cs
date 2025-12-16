using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFleetManAPI.Application.DTOs;
using MyFleetManAPI.Application.DTOs.Employee;
using System.Net;

namespace MyFleetManAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {

        }

        [HttpPost]
        [Route("create_user")]
        public async Task<ResponseDto> CreateUser([FromBody] CreateEmployeeDto employee)
        {
            ResponseDto response = new ResponseDto();
            if (employee == null)
            {
                response.StatusCode=Convert.ToInt32(HttpStatusCode.OK.ToString());
                response.StatusMessage = "Employee dto is null";
                response.Data = employee;
            }
            else
            {

            }
            return response;
        }


    }
}
