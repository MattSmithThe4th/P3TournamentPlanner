using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P3TournamentPlanner.Shared;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase {
        [HttpGet]
        public Contactinfo Get(string testID) {
            string id;
            DatabaseQuerys db = new DatabaseQuerys();
            DataTable dt;

            if (testID == null) {
                //Production
                Console.WriteLine("Production Code");
                Console.WriteLine(HttpContext.User.FindFirstValue("sub"));
                id = HttpContext.User.FindFirstValue("sub");

            } else {
                //Med testID
                Console.WriteLine("Test Code");
                id = testID;
            }

            Console.WriteLine($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID = '{id}'");
            dt = db.PullTable($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID = '{id}'");

            return new Contactinfo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
        }
    }
}
