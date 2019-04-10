using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAspNetCore.Models;
using JWTAspNetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // GET: api/Authentication
        [HttpGet]
        public IEnumerable<string> Get()
        {
            AuthenticationService service = new AuthenticationService();
            service.GetToken("asdf", "SADFSDAf");
            return new string[] { "value1", "value2" };
        }

        // GET: api/Authentication/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            AuthenticationService service = new AuthenticationService();
            return "value";
        }

        // POST: api/Authentication
        [HttpPost]
        public string Post([FromBody] AuthenticationRequest authenticationRequest)
        {
            AuthenticationService service = new AuthenticationService();
            string token = service.GetToken(authenticationRequest.userName, authenticationRequest.passWord);

            service.ValidateAndDecode(token);

            return token;
        }

        // PUT: api/Authentication/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
