using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public List<Club> Get() {
            Console.WriteLine("Get Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            List<Club> clubList = new List<Club>();

            DataTable dt;

            dt = db.PullTable($"select clubID, clubName, clubAddress from ClubDB");

            foreach (DataRow r in dt.Rows) {
                clubList.Add(new Club((int)r[0], r[1].ToString(), r[2].ToString()));
            }

            Console.WriteLine(clubList);

            return clubList;
        }

        [HttpGet ("api/Iklub")]
        public Club Get(int clubID)
        {
            DatabaseQuerys db = new DatabaseQuerys();

            Club club = new Club();

            DataTable dt;

            dt = db.PullTable($"select clubName, clubAddress from ClubDB where clubID = " + clubID);

            foreach (DataRow r in dt.Rows)
            {
                club.name = r[0].ToString();
                club.address = r[1].ToString();
            }

            return club;
        }

        [HttpPost]
        public List<Club> Post(Club club) {
            Console.WriteLine("Post Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            string command = $"insert into ClubDB(clubName, clubAddress) values('{club.name}', '{club.address}')";

            db.InsertToTable(command);

            return Get();
        }

        [HttpPut]
        public void Put(Club club, int clubID) {
            Console.WriteLine("Put Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            string command = $"update clubDB set clubID = {club.clubID}, clubName = {club.name}, clubAddress = {club.address} where clubID = {clubID}";

            db.InsertToTable(command);
        }
    }
}
