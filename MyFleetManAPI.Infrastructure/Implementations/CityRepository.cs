using MyFleetManAPI.Infrastructure.Contracts;
using MyFleetManAPI.Infrastructure.Data;
using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Infrastructure.Implementations
{
    public class CityRepository : ICityRepository
    {
        private readonly MyFleetManDbContext _context;
        public CityRepository(MyFleetManDbContext context)
        {
            _context = context;
        }
        public async Task<TblCitymaster> AddAsync(TblCitymaster city)
        {
            _context.TblCitymasters.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }
    }
}
