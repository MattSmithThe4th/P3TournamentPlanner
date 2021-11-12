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
    public class SingularMatchController : ControllerBase {
        [HttpGet]
        public Match Get(int matchID)
        {
            Console.WriteLine("Get Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            Match match = new Match();
            
            DataTable matchTable, teamTable, clubTable;

            SqlCommand command = new SqlCommand($"select divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, " +
                $"startTime, playedFlag, hostClubID, serverIP, map from MatchDB where matchID = @matchID");
            command.Parameters.Add(new SqlParameter("matchID", matchID));

            matchTable = db.PullTable(command);

            foreach (DataRow r in matchTable.Rows)
            {
                List<Team> teamList = new List<Team>();
                for (int i = 0; i < 2; i++)
                {
                    command = new SqlCommand($"select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, " +
                    $"matchesLost, roundsLost, roundsWon, points, managerID, archiveFlag from TeamsDB where teamID = @teamID");
                    command.Parameters.Add(new SqlParameter("teamID", (int)r[3 + i]));
                    teamTable = db.PullTable(command);

                    foreach (DataRow row in teamTable.Rows)
                    {
                        teamList.Add(new Team((int)row[0], (int)row[2], (int)row[3], (string)row[4], (int)row[5], (int)row[6], (int)row[7], (int)row[8], (int)row[9], (int)row[10], (int)row[11], (int)row[12], (int)row[13], Convert.ToBoolean(row[15])));
                    }

                }
                match = new Match((int)r[0], teamList, (string)r[7], (int)r[8], (int)r[5], (int)r[6], (int)r[9], (string)r[10], (string)r[11]);
            }

            return match;
        }
    }
}
