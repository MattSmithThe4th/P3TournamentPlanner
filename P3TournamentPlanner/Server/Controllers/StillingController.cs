using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P3TournamentPlanner.Shared;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Administrator")]
    public class StillingController : ControllerBase {

        //Runs when a get request is send to /Stilling. It creates a list of teams in the given league and division,
        //based on data in the database. This list is then send as response, as a json.
        [HttpGet]
        public List<Team> Get(string league, int division) {
            Console.WriteLine("Get Recieved!");
            Console.WriteLine("league: " + league);
            Console.WriteLine("division: " + division);

            DatabaseQuerys db = new DatabaseQuerys();
            List<Team> teamList = new List<Team>();
            DataTable dt;

            //// ----------- Mock Objects --------------
            //teamList.Add(new Team("Team 1", 1, 5, 5, 0, 0, 15));
            //teamList.Add(new Team("Team 2", 2, 5, 3, 1, 1, 10));
            //teamList.Add(new Team("Team 3", 3, 5, 0, 1, 5, 1));
            //// --------------- End --------------------

            //Pulls from database, to .NET datatable
            dt = db.PullTable("select teamName, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, points from TeamsDB where divisionID = " + division + " and leagueID = '" + league + "'");

            //Creates teamList, based on said data
            foreach(DataRow r in dt.Rows)
            {
                teamList.Add(new Team(r[0].ToString(), (int)r[1], (int)r[2], (int)r[3], (int)r[4], (int)r[5], (int)r[6]));
            }

            return teamList;
        }
    }
}
