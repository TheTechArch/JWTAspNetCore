using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAspNetCore.Models
{
    public class AuthenticationRequest
    {
        public string userName { get; set; }

        public string passWord { get; set; }

    }
}
