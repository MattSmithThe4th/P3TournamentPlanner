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
using Microsoft.Data.SqlClient;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase {
        //GET
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
            SqlCommand command = new SqlCommand($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID=@userID");
            command.Parameters.Add(new SqlParameter("userID", id));
            dt = db.PullTable(command);

            return new Contactinfo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
        }

        //POST

        //[HttpPost]
        //public void Post(Contactinfo ci, string userIDString) {
        //    DatabaseQuerys db = new DatabaseQuerys();
            
        //    if (userIDString == null) {
        //        userIDString = HttpContext.User.FindFirstValue("sub");
        //    }
            
        //    SqlCommand command = new SqlCommand($"use GeneralDatabase insert into ContactInfoDB(userID, contactName, tlfNumber, discordID, email) values ({userIDString}, {ci.name}, {ci.tlfNr}, {ci.discordID}, {ci.email})");
        //    db.InsertToTable(command);
        //}
    }
}
