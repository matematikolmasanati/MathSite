using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Core.Extensions
{  
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal?.FindAll(claimType)?.Select(claim => claim.Value).ToList();
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }

       
    }
}
//Extension yazmak zordur ama verimi de çoktur -El Hüseyni ฅʕ•̫͡•ʔฅฅʕ•̫͡•ʔฅ(╬▔皿▔)╯(╬▔皿▔)╯(╬▔皿▔)╯(╬▔皿▔)╯(╬▔皿▔)╯