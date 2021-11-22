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
using Microsoft.Data.SqlClient;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Administrator")]
    public class StillingController : ControllerBase {

        //Runs when a get request is send to /Stilling. It creates a list of teams in the given league and division,
        //based on data in the database. This list is then send as response, as a json.
        [HttpGet]
        public List<Team> Get(int league, int division) {
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
            SqlCommand command = new SqlCommand($"select clubID, teamName, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, points from TeamsDB where divisionID = @division and leagueID = @league");
            command.Parameters.Add(new SqlParameter("division", division));
            command.Parameters.Add(new SqlParameter("league", league));
            dt = db.PullTable(command);

            //Creates teamList, based on said data
            foreach(DataRow r in dt.Rows)
            {
                teamList.Add(new Team((int)r[0], r[1].ToString(), (int)r[2], (int)r[3], (int)r[4], (int)r[5], (int)r[6], (int)r[7]));
            }

            foreach(Team t in teamList) {
                Console.WriteLine(t.teamName);
            }

            return teamList;
        }

        //PUT
        [HttpPut]
        public void Put(Team team) {
            Console.WriteLine("Put Got!");
            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("use GeneralDatabase update TeamsDB set clubID = @clubID, divisionID = @divisionID, leagueID = @leagueID, teamName = @teamName, teamRating = @teamRating, placement = @placement, matchPlayed = @matchPlayed, matchesWon = @matchesWon, matchesDraw = @matchesDraw, matchesLost = @matchesLost, roundsWon = @roundsWon, roundsLost = @roundsLost, points = @points, managerID = @managerID, archiveFlag = @archiveFlag where teamID = @teamID");

            command.Parameters.Add(new SqlParameter("clubID", team.clubID));
            command.Parameters.Add(new SqlParameter("divisionID", team.divisionID));
            command.Parameters.Add(new SqlParameter("leagueID", team.leagueID));
            command.Parameters.Add(new SqlParameter("teamName", team.teamName));
            command.Parameters.Add(new SqlParameter("teamRating", team.teamSkillRating));
            command.Parameters.Add(new SqlParameter("placement", team.placement));
            command.Parameters.Add(new SqlParameter("matchPlayed", team.matchesPlayed));
            command.Parameters.Add(new SqlParameter("matchesWon", team.matchesWon));
            command.Parameters.Add(new SqlParameter("matchesDraw", team.matchesDraw));
            command.Parameters.Add(new SqlParameter("matchesLost", team.matchesLost));
            command.Parameters.Add(new SqlParameter("roundsWon", team.roundsWon));
            command.Parameters.Add(new SqlParameter("roundsLost", team.roundsLost));
            command.Parameters.Add(new SqlParameter("points", team.points));
            command.Parameters.Add(new SqlParameter("managerID", team.manager.userID));
            command.Parameters.Add(new SqlParameter("archiveFlag", Convert.ToInt32(team.archiveFlag)));
            command.Parameters.Add(new SqlParameter("teamID", team.teamID));

            Console.WriteLine(command.CommandText);

            db.InsertToTable(command);

            Console.WriteLine("Put End");
        }

        //Tror ikke den har behov for POST
        //[HttpPost]
        //public void Post() {

        //}







    }
}