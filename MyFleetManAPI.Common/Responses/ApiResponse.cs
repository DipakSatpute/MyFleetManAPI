using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Common.Responses
{
    public class ApiResponse<T>
    {
        public int statusCode { get; set; }
        public string? statusMessage { get; set; }
        public object? Data { get; set; }
    }
}
