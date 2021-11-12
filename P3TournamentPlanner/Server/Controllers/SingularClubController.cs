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
    public class SingularClubController : ControllerBase {
        [HttpGet]
        public Club Get(int clubID)
        {
            Console.WriteLine("Get Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            Club club = new Club();

            DataTable dt;

            SqlCommand command = new SqlCommand($"select clubName, clubAddress from ClubDB where clubID = @clubID");
            command.Parameters.Add(new SqlParameter("clubID", clubID));
            dt = db.PullTable(command);

            foreach (DataRow r in dt.Rows)
            {
                club = new Club((int)r[0], r[1].ToString(), r[2].ToString());
            }

            return club;
        }
    }
}
