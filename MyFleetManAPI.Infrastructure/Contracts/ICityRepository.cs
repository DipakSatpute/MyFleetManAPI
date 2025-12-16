using MyFleetManAPI.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Infrastructure.Contracts
{
    public interface ICityRepository
    {
        Task<TblCitymaster> AddAsync(TblCitymaster city);

    }
}
