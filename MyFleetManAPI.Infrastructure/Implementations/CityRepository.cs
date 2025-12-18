using Microsoft.EntityFrameworkCore;
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
        public async Task<List<TblCitymaster>> GetAllCityAsync()
        {
            var cities = await _context.TblCitymasters.Where(d => d.Active == 1).ToListAsync();
            return cities;
        }

        public async Task<TblCitymaster> UpdateCityAsync(TblCitymaster city)
        {
            try
            {
                await _context.SaveChangesAsync();
                return city;
            }
            catch (Exception)
            {

                throw;
            }
            //var cityToUpdate = await _context.TblCitymasters.Where(d => d.CityId == city.CityId).FirstOrDefaultAsync();
            //if (cityToUpdate != null)
            //{
            //    cityToUpdate.CityName = city.CityName;
            //    cityToUpdate.IsMainBranch = city.IsMainBranch;
            //    cityToUpdate.IsServingCity = city.IsServingCity;
            //    cityToUpdate.Active = city.Active;
            //    cityToUpdate.ModifiedBy = city.ModifiedBy;
            //    cityToUpdate.ModifiedOn = DateTime.Now;
            //    await _context.SaveChangesAsync();
            //    return cityToUpdate;
            //}
            //else
            //{
            //    return null;
            //}
        }
        public async Task<TblCitymaster?> GetCityByIdAsync(int cityId)
        {
            return await _context.TblCitymasters.Where(d =>d.CityId==cityId && d.Active == 1).FirstOrDefaultAsync();
        }
    }
}
