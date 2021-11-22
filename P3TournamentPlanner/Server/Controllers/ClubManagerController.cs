using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using P3TournamentPlanner.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClubManagerController : ControllerBase {
        [HttpGet]
        public List<ClubManager> Get(int clubID)
        {
            Console.WriteLine("Get Received!");

            DatabaseQuerys db = new DatabaseQuerys();
            DataTable dt1;

            List<ClubManager> clubManagers = new List<ClubManager>();

            SqlCommand command = new SqlCommand("select userID from ClubManagerDB where clubID = @clubID");
            command.Parameters.Add(new SqlParameter("clubID", clubID));
            dt1 = db.PullTable(command);

            foreach (DataRow r in dt1.Rows)
            {
                DataTable dt2;

                Contactinfo contactinfo = new Contactinfo();

                command = new SqlCommand("select contactName, tlfNumber, discordID, email from ContactInfoDB where userID = @userID");
                command.Parameters.Add(new SqlParameter("userID", r[0].ToString()));

                dt2 = db.PullTable(command);

                foreach (DataRow row in dt2.Rows)
                {
                    contactinfo = new Contactinfo(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }

                clubManagers.Add(new ClubManager(contactinfo, r[0].ToString(), clubID));
            }
            return clubManagers;
        }

        [HttpPost]
        public void Post(ClubManager cm)
        {
            Console.WriteLine("Post Received!");

            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("insert into ClubManagerDB(clubID, userID) values (@clubID, @userID)");

            command.Parameters.Add(new SqlParameter("clubID", cm.ClubID));
            command.Parameters.Add(new SqlParameter("userID", cm.userID));

            db.InsertToTable(command);

            command = new SqlCommand("insert into ContactInfoDB(contactName, tlfNumber, discordID, email, userID) values(" +
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

        [HttpDelete]
        [Route("Delete/{userID}")]
        public void Delete(string userID)
        {
            Console.WriteLine("Delete Received!");

            DatabaseQuerys db = new();

            SqlCommand command = new("delete from ContactInfoDB where userID = @userID");
            command.Parameters.Add(new SqlParameter("userID", userID));

            db.DeleteRow(command);

            command = new("delete from ClubManagerDB where userID = @userID");
            command.Parameters.Add(new SqlParameter("userID", userID));

            db.DeleteRow(command);
        }
    }
}
