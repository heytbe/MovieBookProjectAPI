using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.SignService
{
    public static class SimetricSecurity
    {
        public static SecurityKey SymmetricKey(string securitykey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
        }
    }
}
