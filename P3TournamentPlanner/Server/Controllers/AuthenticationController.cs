using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        [HttpGet]
        public bool Get(string role)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;

            if (principal.IsInRole(role))
            {
                Console.WriteLine("POGGERS!");
                return true;
            }
            else
            {
                Console.WriteLine("Ikke særlig Gucci og så noget");
                return false;
            }
        }
    }
}
