using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.DTOs.CityMaster
{
    public class UpdateCityDto : UpdateDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public int IsMainBranch { get; set; }
        public int IsServingCity { get; set; }
    }
}
