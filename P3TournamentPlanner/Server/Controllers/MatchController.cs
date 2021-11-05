using Microsoft.AspNetCore.Mvc;
using P3TournamentPlanner.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class MatchController : ControllerBase {
        public List<Match> Get() {
            Console.WriteLine("Get Recieved!");

            //Console.WriteLine("Match ID: " + matchID.GetValueOrDefault());


            DatabaseQuerys db = new DatabaseQuerys();

            List<Match> matchList = new List<Match>();
            List<Team> teamList = new List<Team>();


            DataTable matchTable, teamTable;

            matchTable = db.PullTable($"select matchID, divisionID, leagueID, team1, team2, team1Score, team2Score, " +
                $"startTime, playedFlag, hostClubID, serverIP from MatchDB");


            foreach (DataRow r in matchTable.Rows) {
                for (int i = 0; i < 2; i++) {
                    teamTable = db.PullTable($"select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, " +
                    $"matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag from TeamsDB where teamID = {(int)r[3+i]}");
                    foreach (DataRow row in teamTable.Rows) {
                        teamList.Add(new Team((int)r[0], (int)r[1], (int)r[2], (int)r[3], r[4].ToString(), (int)r[5], (int)r[6], (bool)r[7], (int)r[8], 
                            (int)r[9], (int)r[10], (int)r[11], (int)r[12], (int)r[13], r[14].ToString(), (bool)r[15]));
                    }
                    
                }
             
                matchList.Add(new Match((int)r[0], (int)r[1], (int)r[2], teamList, r[7].ToString(), (bool)r[8], (int)r[9], r[10].ToString()));
            }

            Console.WriteLine(matchTable);

            foreach (Match t in matchList) {
                //Console.WriteLine(t.DivID);
            }

            return matchList;
        }
    }
}
