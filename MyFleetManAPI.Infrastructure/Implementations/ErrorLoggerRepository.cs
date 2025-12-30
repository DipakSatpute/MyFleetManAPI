using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MyFleetManAPI.DataAccess.Data;
using MyFleetManAPI.DataAccess.Models;
using MyFleetManAPI.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Infrastructure.Implementations
{
    public class ErrorLoggerRepository : IErrorLoggerRepository
    {
        private readonly MyFleetManDbContext _dbContext;
        public ErrorLoggerRepository(MyFleetManDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task LogAsync(Exception ex, HttpContext context)
        {
            var routeData = context.GetRouteData();

            var log = new TblErrorlog
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace,

                Controller = routeData.Values["controller"]?.ToString(),
                Action = routeData.Values["action"]?.ToString(),

                Path = context.Request.Path,
                Method = context.Request.Method
            };

            _dbContext.TblErrorlogs.Add(log);
            await _dbContext.SaveChangesAsync();
        }
    }
}
