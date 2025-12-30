using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Infrastructure.Contracts
{
    public interface IErrorLoggerRepository
    {
        Task LogAsync(Exception exception, HttpContext context);
    }
}
