using Microsoft.AspNetCore.Http;
using MyFleetManAPI.Application.Contracts;
using MyFleetManAPI.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.Implementations
{

    public class ErrorLoggerService : IErrorLoggerService
    {
        private readonly IErrorLoggerRepository _errorLoggerRepository;
        public ErrorLoggerService(IErrorLoggerRepository errorLoggerRepository) 
        {
            _errorLoggerRepository= errorLoggerRepository;
        }

        public Task LogAsync(Exception exception, HttpContext context)
        {
            _errorLoggerRepository.LogAsync(exception, context);
            return Task.CompletedTask;
        }
    }
}
