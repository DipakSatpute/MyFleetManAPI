using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.Contracts
{
    public interface IErrorLoggerService
    {
        Task LogAsync(Exception exception, HttpContext context);
    }
}
