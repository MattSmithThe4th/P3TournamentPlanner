using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        public void Post(ClubManager cm)
        {
            Console.WriteLine("Put Received!");

            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("use GeneralDatabase insert into ClubManagerDB(clubID, userID) values (@clubID, @userID)");

            command.Parameters.Add(new SqlParameter("clubID", cm.ClubID));
            command.Parameters.Add(new SqlParameter("userID", cm.userID));

            db.InsertToTable(command);

            command = new SqlCommand("use GeneralDatabase insert into ContactInfoDB(contactName, tlfNumber, discordID, email, userID) values(" +
                "@contactName, @tlfNumber, @discordID, @email, @userID)");

            command.Parameters.Add(new SqlParameter("contactName", cm.contactinfo.name));
            command.Parameters.Add(new SqlParameter("tlfNumber", cm.contactinfo.tlfNr));
            command.Parameters.Add(new SqlParameter("discordID", cm.contactinfo.discordID));
            command.Parameters.Add(new SqlParameter("email", cm.contactinfo.email));
            command.Parameters.Add(new SqlParameter("userID", cm.userID));

            db.InsertToTable(command);
        }

        [HttpPut]
        public void Put(ClubManager cm)
        {
            Console.WriteLine("Put Received!");

            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("update ClubManagerDB set clubID = @clubID where userID = @userID");

            command.Parameters.Add(new SqlParameter("clubID", cm.ClubID));
            command.Parameters.Add(new SqlParameter("userID", cm.userID));

            db.InsertToTable(command);

            command = new SqlCommand("update ContactInfoDB set " +
                "contactName = @contactName, " +
                "tlfNumber = @tlfNumber, " +
                "discordID = @discordID, " +
                "email = @email " +
                "where userID = @userID");

            command.Parameters.Add(new SqlParameter("contactName", cm.contactinfo.name));
            command.Parameters.Add(new SqlParameter("tlfNumber", cm.contactinfo.tlfNr));
            command.Parameters.Add(new SqlParameter("discordID", cm.contactinfo.discordID));
            command.Parameters.Add(new SqlParameter("email", cm.contactinfo.email));
            command.Parameters.Add(new SqlParameter("userID", cm.userID));

            db.InsertToTable(command);
        }
    }
}
