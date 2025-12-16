using MyFleetManAPI.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Common.Extensions
{
    public static class RoleExtensions
    {
        public static string ToRoleName(this UserRoles role) => role.ToString();
    }
}
