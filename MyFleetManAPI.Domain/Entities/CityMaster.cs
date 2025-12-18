using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Domain.Entities
{
    public class CityMaster
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public int? IsMainBranch { get; set; }
        public bool? IsServingCity { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
