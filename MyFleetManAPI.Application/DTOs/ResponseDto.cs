using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.DTOs
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
