using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JWTAspNetCore.Services
{
    public class AuthenticationService
    {

        public string GetToken(string username, string password)
        {
            // authentication successful so generate jwt token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = GetSigningCredentials()
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenstring = tokenHandler.WriteToken(token);

            return tokenstring;
        }



        private SigningCredentials GetSigningCredentials()
        {
            X509Certificate2 cert = new X509Certificate2("C:\\Repos\\JWTAspNetCore\\JWTAspNetCore\\jwtselfsignedcert.pfx", "qwer1234");
            SigningCredentials creds = new X509SigningCredentials(cert, SecurityAlgorithms.RsaSha256);
            return creds;
        }

    }




}
