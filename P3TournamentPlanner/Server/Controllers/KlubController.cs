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
        public List<Club> Get() {
            Console.WriteLine("Get Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            List<Club> clubList = new List<Club>();

            DataTable dt;

            SqlCommand command = new SqlCommand($"select clubID, clubName, clubAddress from ClubDB");
            dt = db.PullTable(command);

            //dt = db.PullTable($"select clubID, clubName, clubAddress from ClubDB");


            foreach (DataRow r in dt.Rows) {
                clubList.Add(new Club(r[0].ToString(), r[1].ToString(), r[2].ToString()));
            }

            Console.WriteLine(clubList);

            return clubList;
        }
    }
}
