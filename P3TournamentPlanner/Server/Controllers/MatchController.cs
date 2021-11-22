using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using P3TournamentPlanner.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        [HttpGet]
        public List<Match> Get(int division)
        {
            Console.WriteLine("Get Recieved!");
            Console.WriteLine(division);


            DatabaseQuerys db = new DatabaseQuerys();

            List<Match> matchList = new List<Match>();
            


            DataTable matchTable, teamTable, contactTable;

            matchTable = db.PullTable($"select matchID, divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, " +
                $"startTime, playedFlag, hostClubID, serverIP, map from MatchDB where divisionID = " + division);


            foreach (DataRow r in matchTable.Rows)
            {
                List<Team> teamList = new List<Team>();
                for (int i = 0; i < 2; i++)
                {
                    teamTable = db.PullTable($"select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, " +
                    $"matchesLost, roundsLost, roundsWon, points, managerID, archiveFlag from TeamsDB where teamID = {(int)r[3 + i]}");
                    foreach (DataRow row in teamTable.Rows)
                    {
                        contactTable = db.PullTable($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID='{row[14]}'");

                        Contactinfo contactInfo = new Contactinfo((string)contactTable.Rows[0][0], (string)contactTable.Rows[0][1], (string)contactTable.Rows[0][2], (string)contactTable.Rows[0][3]);
                        ClubManager manager = new ClubManager(contactInfo, (string)row[14]);
                        teamList.Add(new Team((int)row[0], (int)row[2], (string)row[4], (int)row[5], (int)row[6], (int)row[7], (int)row[8], (int)row[9], (int)row[10], (int)row[11], (int)row[12], (int)row[13], manager, Convert.ToBoolean(row[15])));

                        //teamList.Add(new Team((int)row[0], (int)row[1], (int)row[2], (int)row[3], row[4].ToString(), (int)row[5], (int)row[6], (int)row[7], (int)row[8],
                        //    (int)row[9], (int)row[10], (int)row[11], (int)row[12], (int)row[13], row[14].ToString(), (int)row[15]));
                    }

                }

                matchList.Add(new Match((int)r[0], (int)r[1], (int)r[2], teamList, (int)r[5], (int)r[6], r[7].ToString(), (int)r[8], (int)r[9], r[10].ToString())); //do something with results
            }

            Console.WriteLine(matchTable);

            return matchList;
        }

        [HttpPost]
        public void Post(Match match) {
            Console.WriteLine("Post Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("insert into MatchDB(divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, startTime, playedFlag, hostClubID, serverIP) " +
                "values(@matchDivisionID, @leagueID, @team1ID, @team2ID, @team1Score, @team2Score, @startTime, " +
                "@playedFlag, @hostClubID, @serverIP)");
            command.Parameters.Add(new SqlParameter("matchDivisionID", match.divisionID));
            command.Parameters.Add(new SqlParameter("leagueID", match.leagueID));
            command.Parameters.Add(new SqlParameter("team1ID", match.teams[0]));
            command.Parameters.Add(new SqlParameter("team2ID", match.teams[1]));
            command.Parameters.Add(new SqlParameter("team1Score", match.resultTeam1));
            command.Parameters.Add(new SqlParameter("team2Score", match.resultTeam2));
            command.Parameters.Add(new SqlParameter("startTime", match.startTime));
            command.Parameters.Add(new SqlParameter("playedFlag", match.playedFlag));
            command.Parameters.Add(new SqlParameter("hostClubID", match.clubHostID));
            command.Parameters.Add(new SqlParameter("serverIP", match.serverIP));

            db.InsertToTable(command);
        }

        [HttpPut]
        public void Put(Match match, int matchID) {
            Console.WriteLine("Put Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("update MatchDB set divisionID = @matchDivisionID, leagueID = @leagueID, team1ID = @team1ID, team2ID = @team2ID, " +
                $"team1Score = @team1Score, team2Score = @team2Score, startTime = @startTime, " +
                $"playedFlag = @playedFlag, hostClubID = @hostClubID, serverIP = @serverIP where matchID = @matchID)");
            command.Parameters.Add(new SqlParameter("matchDivisionID", match.divisionID));
            command.Parameters.Add(new SqlParameter("leagueID", match.leagueID));
            command.Parameters.Add(new SqlParameter("team1ID", match.teams[0]));
            command.Parameters.Add(new SqlParameter("team2ID", match.teams[1]));
            command.Parameters.Add(new SqlParameter("team1Score", match.resultTeam1));
            command.Parameters.Add(new SqlParameter("team2Score", match.resultTeam2));
            command.Parameters.Add(new SqlParameter("startTime", match.startTime));
            command.Parameters.Add(new SqlParameter("playedFlag", match.playedFlag));
            command.Parameters.Add(new SqlParameter("hostClubID", match.clubHostID));
            command.Parameters.Add(new SqlParameter("serverIP", match.serverIP));
            command.Parameters.Add(new SqlParameter("matchID", matchID));

            db.InsertToTable(command);
        }
    }
}
