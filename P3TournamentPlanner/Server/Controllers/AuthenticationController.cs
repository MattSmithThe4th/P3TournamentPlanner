using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using P3TournamentPlanner.Shared;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
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

        [Authorize]
        [HttpGet("isManager")]
        public bool GetManBool(string ID1, string ID2) {
            //Jeg sværger.. Det er ikk scuffed
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            if(principal.IsInRole("Administrator")) return true;

            List<string> clubIDList = new List<string>();
            clubIDList.Add(ID1);
            clubIDList.Add(ID2);

            bool isManager = false;
            string curUserID;

            DatabaseQuerys db = new DatabaseQuerys();
            DataTable dt;

            curUserID = HttpContext.User.FindFirstValue("sub");

            Console.WriteLine("id: " + curUserID);

            SqlCommand command = new SqlCommand("select clubID from ClubManagerDB where userID = @userID");
            command.Parameters.Add(new SqlParameter("userID", curUserID));
            dt = db.PullTable(command);

            foreach(string clubID in clubIDList) {
                foreach(DataRow r in dt.Rows) {
                    if(r[0].ToString() == clubID) {
                        isManager = true;
                        break;
                    }
                }

                if(isManager) break;
            }

            return isManager;
        }

        [Authorize]
        [HttpGet("navbar")]
        public ClubManager GetClubManager()
        {
            string curUserID;
            curUserID = HttpContext.User.FindFirstValue("sub");

            DatabaseQuerys db = new DatabaseQuerys();
            DataTable dt;

            SqlCommand command = new SqlCommand("select clubID from ClubManagerDB where userID = @userID");
            command.Parameters.Add(new SqlParameter("userID", curUserID));

            dt = db.PullTable(command);

            ClubManager clubManager = new ClubManager((int)dt.Rows[0][0], curUserID);

            return clubManager;
        }
    }
}
