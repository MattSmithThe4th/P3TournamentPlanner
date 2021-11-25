using Microsoft.AspNetCore.Authorization;
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
    public class KlubController : ControllerBase {

        [HttpGet("klub")]
        public Club Get(int clubID)
        {
            Console.WriteLine("Get Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            Club club = new Club();

            DataTable dt;

            SqlCommand command = new SqlCommand($"select clubID, clubName, clubAddress, clubLogo from ClubDB where clubID = @clubID");
            command.Parameters.Add(new SqlParameter("clubID", clubID));
            dt = db.PullTable(command);

            foreach (DataRow r in dt.Rows)
            {
                club = new Club((int)r[0], r[1].ToString(), r[2].ToString(), r[3].ToString());
            }

            Console.WriteLine(club.base64Logo);

            return club;
        }

        [HttpGet]
        public List<Club> Get() {
            Console.WriteLine("Get Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            List<Club> clubList = new List<Club>();

            DataTable dt;

            SqlCommand command = new SqlCommand($"select clubID, clubName, clubAddress, clubLogo from ClubDB");
            dt = db.PullTable(command);

            //dt = db.PullTable($"select clubID, clubName, clubAddress from ClubDB");


            foreach (DataRow r in dt.Rows) {
                clubList.Add(new Club((int)r[0], r[1].ToString(), r[2].ToString(), r[3].ToString()));
            }

            Console.WriteLine(clubList);

            return clubList;
        }

        //[HttpPost]
        //public List<Club> Post(Club club)
        //{
        //    Console.WriteLine("Post Recieved!");

        //    DatabaseQuerys db = new DatabaseQuerys();

        //    string command = $"insert into ClubDB(clubName, clubAddress) values('{club.name}', '{club.address}')";

        //    db.InsertToTable(command);

        //    return Get();
        //}

        //[HttpPut]
        //public void Put(Club club, int clubID)
        //{
        //    Console.WriteLine("Put Recieved!");

        //    DatabaseQuerys db = new DatabaseQuerys();

        //    string command = $"update clubDB set clubID = {club.clubID}, clubName = {club.name}, clubAddress = {club.address} where clubID = {clubID}";

        //    db.InsertToTable(command);
        //}

        [Authorize]
        [HttpPut]
        public void Put(Club club)
        {
            Console.WriteLine("Put Got!");
            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("use GeneralDatabase update ClubDB set clubName = @clubName, clubAddress = @clubAddress, clubLogo = @clubLogo where clubID = @clubID");

            //command.Parameters.Add(new SqlParameter("clubID",));
            command.Parameters.Add(new SqlParameter("clubName", club.name));
            command.Parameters.Add(new SqlParameter("clubAddress", club.address));
            command.Parameters.Add(new SqlParameter("clubLogo", club.base64Logo));
            command.Parameters.Add(new SqlParameter("clubID", club.clubID));

            Console.WriteLine(club.base64Logo);

            Console.WriteLine(command.CommandText);

            db.InsertToTable(command);

            Console.WriteLine("Put End");
        }

        [Authorize]
        [HttpPost]
        public void Post(Club club)
        {
            DatabaseQuerys db = new DatabaseQuerys();

            //SqlCommand command = new SqlCommand($"use GeneralDatabase insert into ContactInfoDB(userID, contactName, tlfNumber, discordID, email) values ({userIDString}, {ci.name}, {ci.tlfNr}, {ci.discordID}, {ci.email})");
            SqlCommand command = new SqlCommand($"use GeneralDatabase insert into ClubDB(clubName, clubAddress, clubLogo) values (@clubName, @clubAddress, @clubLogo)");
            command.Parameters.Add(new SqlParameter("clubName", club.name));
            command.Parameters.Add(new SqlParameter("clubAddress", club.address));
            command.Parameters.Add(new SqlParameter("clubLogo", club.base64Logo));
            db.InsertToTable(command);
        }
    }
}
