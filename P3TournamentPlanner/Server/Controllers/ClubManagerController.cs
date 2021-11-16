using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3TournamentPlanner.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClubManagerController : ControllerBase {
        [HttpPost]
        public void Post(ClubManager cm, Contactinfo ci)
        {
            Console.WriteLine("Post Received!");

            DatabaseQuerys db = new DatabaseQuerys();

            string command = $"insert into ClubManagerDB(clubID int, userID varchar(64)) values({cm.userID})";

            db.InsertToTable(command);

            command = $"insert into ContactInfoDB(userID, contactName, tlfNumber, discordID, email) values('{ci.userID}', '{ci.contactName}', '{ci.tlfNumber}', '{ci.discordID}', '{ci.email}')";

            db.InsertToTable(command);
        }

        [HttpPut]
        public void Put(ClubManager cm, Contactinfo ci, int userID)
        {
            Console.WriteLine("Put Received!");

            DatabaseQuerys db = new DatabaseQuerys();

            string command = $"update ClubManagerDB set userID = '{cm.userID}' where userID = {userID})";

            db.InsertToTable(command);

            command = $"update ContactInfoDB set userID = '{ci.userID}', contactName = '{ci.contactName}', tlfNumber = '{ci.tlfNumber}', discordID = '{ci.discordID}', email = '{ci.email}' where userID = {userID}";

            db.InsertToTable(command);
        }
    }
}
