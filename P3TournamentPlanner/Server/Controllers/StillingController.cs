using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P3TournamentPlanner.Shared;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class StillingController : ControllerBase {

        //Runs when a get request is send to /Stilling. It creates a list of teams in the given league and division,
        //based on data in the database. This list is then send as response, as a json.
        //[AllowAnonymous]
        [HttpGet]
        public List<Team> Get(string league, int division) {
            Console.WriteLine("Get Recieved!");
            Console.WriteLine("league: " + league);
            Console.WriteLine("division: " + division);

            //string league, int division

            DatabaseQuerys db = new DatabaseQuerys();

            List<Team> teamList = new List<Team>();
            //// ----------- Mock Objects --------------
            //teamList.Add(new Team("Team 1", 1, 5, 5, 0, 0, 15));
            //teamList.Add(new Team("Team 2", 2, 5, 3, 1, 1, 10));
            //teamList.Add(new Team("Team 3", 3, 5, 0, 1, 5, 1));

            //// --------------- End --------------------

            //string qString = "insert into TeamsDB(divisionID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, points, managerTlf) values(1337, 'Team 1', 420, 1, 5, 5, 0, 0, 15, 88888888);";
            //db.RunQuery(qString);

            //qString = "insert into TeamsDB(divisionID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, points, managerTlf) values(1337, 'Team 2', 419, 2, 5, 3, 1, 1, 10, 74658936);";
            //db.RunQuery(qString);

            //qString = "insert into TeamsDB(divisionID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, points, managerTlf) values(1337, 'Team 3', 418, 3, 5, 0, 1, 5, 1, 64758351);";
            //db.RunQuery(qString);

            //Læs parametre få at finde liga/division
            //Aflæs alle hold i denne division fra databasen

            DataTable dt;

            //strArr = db.SelectQuery<string>("select teamName, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, points from TeamsDB where divisionID = 1337", "teamName");

            dt = db.PullTable("select teamName, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, points from TeamsDB where divisionID = " + division);

            foreach(DataRow r in dt.Rows)
            {
                teamList.Add(new Team(r[0].ToString(), (int)r[1], (int)r[2], (int)r[3], (int)r[4], (int)r[5], (int)r[6]));
            }

            Console.WriteLine(dt);

            //Construct dem som objecter, og send listen afsted

            foreach (Team t in teamList) {
                Console.WriteLine(t.name);
            }
            return teamList;
        }
    }
}
