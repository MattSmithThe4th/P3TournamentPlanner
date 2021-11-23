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
    public class MatchController : ControllerBase {
        public List<Match> Get(int? division, int? teamID) {
            Console.WriteLine("Get Recieved!");
            Console.WriteLine(division);

            //Console.WriteLine("Match ID: " + matchID.GetValueOrDefault());


            DatabaseQuerys db = new DatabaseQuerys();

            List<Match> matchList = new List<Match>();

            DataTable matchTable, teamTable, contactTable;

            SqlCommand command;

            if(division != null) {
                command = new SqlCommand($"select matchID, divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, " +
                $"startTime, playedFlag, hostClubID, serverIP, map from MatchDB where divisionID = @div");
                command.Parameters.Add(new SqlParameter("div", division));
            } else {
                command = new SqlCommand($"select matchID, divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, " +
                $"startTime, playedFlag, hostClubID, serverIP, map from MatchDB where team1ID = @teamID or team2ID = @teamID");
                command.Parameters.Add(new SqlParameter("teamID", teamID));
            }

            matchTable = db.PullTable(command);

            foreach(DataRow r in matchTable.Rows) {
                List<Team> teamList = new List<Team>();
                for(int i = 0; i < 2; i++) {
                    command = new SqlCommand($"select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, " +
                    $"matchesLost, roundsLost, roundsWon, points, managerID, archiveFlag from TeamsDB where teamID = @teamID");
                    command.Parameters.Add(new SqlParameter("teamID", (int)r[3 + i]));
                    teamTable = db.PullTable(command);

                    foreach(DataRow row in teamTable.Rows) {
                        command = new SqlCommand($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID = @userID");
                        command.Parameters.Add(new SqlParameter("userID", row[14]));
                        contactTable = db.PullTable(command);

                        //contactTable = db.PullTable($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID='{row[14]}'");

                        Contactinfo contactInfo = new Contactinfo((string)row[14], (string)contactTable.Rows[0][0], (string)contactTable.Rows[0][1], (string)contactTable.Rows[0][2], (string)contactTable.Rows[0][3]);
                        ClubManager manager = new ClubManager(contactInfo, (string)row[14]);
                        teamList.Add(new Team((int)row[0], (int)row[1], (int)row[2], (int)row[3], (string)row[4], (int)row[5], (int)row[6], (int)row[7], (int)row[8], (int)row[9], (int)row[10], (int)row[11], (int)row[12], (int)row[13], manager, Convert.ToBoolean(row[15])));

                        //teamList.Add(new Team((int)row[0], (int)row[1], (int)row[2], (int)row[3], row[4].ToString(), (int)row[5], (int)row[6], (int)row[7], (int)row[8],
                        //    (int)row[9], (int)row[10], (int)row[11], (int)row[12], (int)row[13], row[14].ToString(), (int)row[15]));
                    }

                }

                //"0matchID, 1divisionID, 2leagueID, 3team1ID, 4team2ID, 5team1Score, 6team2Score, 7startTime, 8playedFlag, 9hostClubID, 10serverIP, 11map"

                matchList.Add(new Match((int)r[0], teamList, (string)r[7], Convert.ToBoolean(r[8]), (int)r[5], (int)r[6], (int)r[9], (string)r[10], (string)r[11]));
                //matchList.Add(new Match((int)r[0], (int)r[1], (int)r[2], teamList, r[5] + " - " + r[6], r[7].ToString(), (int)r[8], (int)r[9], r[10].ToString())); //do something with results
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
            command.Parameters.Add(new SqlParameter("team1Score", match.team1Score));
            command.Parameters.Add(new SqlParameter("team2Score", match.team2Score));
            command.Parameters.Add(new SqlParameter("startTime", match.startTime));
            command.Parameters.Add(new SqlParameter("playedFlag", Convert.ToInt32(match.playedFlag)));
            command.Parameters.Add(new SqlParameter("hostClubID", match.clubHostID));
            command.Parameters.Add(new SqlParameter("serverIP", match.serverIP));

            db.InsertToTable(command);
        }

        [HttpPut]
        public void Put(Match match) {
            Console.WriteLine("Put Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("select playedFlag from matchDB where matchID = @matchID");
            command.Parameters.Add(new SqlParameter("matchID", match.matchID));
            DataTable dt = db.PullTable(command);

            //logic check if placement data should change
            if(match.playedFlag && !Convert.ToBoolean(dt.Rows[0][0])) {
                // her når en kamp blev færdig
                updateDivisionStandings(match);
            } else if(match.playedFlag && Convert.ToBoolean(dt.Rows[0][0])) {
                // her hvis spilled kamp havde forkert resultat
                reverseDivisionStandings(match.matchID);
                updateDivisionStandings(match);
            }

            //put to matchDB
            command = new SqlCommand("update MatchDB set divisionID = @matchDivisionID, leagueID = @leagueID, team1ID = @team1ID, team2ID = @team2ID, " +
                $"team1Score = @team1Score, team2Score = @team2Score, startTime = @startTime, " +
                $"playedFlag = @playedFlag, hostClubID = @hostClubID, serverIP = @serverIP where matchID = @matchID)");
            command.Parameters.Add(new SqlParameter("matchDivisionID", match.divisionID));
            command.Parameters.Add(new SqlParameter("leagueID", match.leagueID));
            command.Parameters.Add(new SqlParameter("team1ID", match.teams[0].teamID));
            command.Parameters.Add(new SqlParameter("team2ID", match.teams[1].teamID));
            command.Parameters.Add(new SqlParameter("team1Score", match.team1Score));
            command.Parameters.Add(new SqlParameter("team2Score", match.team2Score));
            command.Parameters.Add(new SqlParameter("startTime", match.startTime));
            command.Parameters.Add(new SqlParameter("playedFlag", Convert.ToInt32(match.playedFlag)));
            command.Parameters.Add(new SqlParameter("hostClubID", match.clubHostID));
            command.Parameters.Add(new SqlParameter("serverIP", match.serverIP));
            command.Parameters.Add(new SqlParameter("matchID", match.matchID));



            db.InsertToTable(command);
        }

        private void reverseDivisionStandings(int matchID) {
            DatabaseQuerys db = new DatabaseQuerys();
            DataTable dt;
            Match match;
            List<Team> teams = new List<Team>();
            SqlCommand command;

            command = new SqlCommand("select * from MatchDB where matchID = @matchID");
            command.Parameters.Add(new SqlParameter("matchID", matchID));
            dt = db.PullTable(command);
            //pull teams hvis id'er er i dt
            //lav teams objecter
            //lav match object
            //reverse udregninger som de er lavet i updateDivisionStandings();
            //update TeamDB
        }

        private void updateDivisionStandings(Match match) {
            DatabaseQuerys db = new DatabaseQuerys();
            List<Team> teams = new List<Team>();
            //DataTable team1DT = new DataTable();
            //DataTable team2DT = new DataTable();
            SqlCommand command;

            //gets list of teams involved in the match
            foreach(Team t in match.teams) {
                command = new SqlCommand("select * from TeamDB where teamID = @teamID");
                command.Parameters.Add(new SqlParameter("teamID", t.teamID));
                DataTable tmpTable = db.PullTable(command);

                foreach(DataRow r in tmpTable.Rows) {
                    teams.Add(new Team((int)r[0], (int)r[11], (int)r[12], (int)r[6], (int)r[7], (int)r[8], (int)r[9], (int)r[10], (int)r[13]));
                }
            }
            //ja det er scuffed
            teams[0].roundsWon += match.team1Score;
            teams[0].roundsLost += match.team2Score;

            teams[1].roundsWon += match.team2Score;
            teams[1].roundsLost += match.team1Score;

            teams[0].matchesPlayed++;
            teams[1].matchesPlayed++;

            if(match.team1Score > match.team2Score) {
                teams[0].matchesWon++;
                teams[1].matchesLost++;

                teams[0].points += 3;
            } else if (match.team1Score < match.team2Score) {
                teams[0].matchesLost++;
                teams[1].matchesWon++;

                teams[1].points += 3;
            } else if (match.team1Score == match.team2Score) {
                teams[0].matchesDraw++;
                teams[0].points++;

                teams[1].matchesDraw++;
                teams[1].points++;
            }

            foreach(Team t in teams) {
                command = new SqlCommand("update MatchDB set matchPlayed = @matchPlayed, matchesWon = @matchesWon, matchesDraw = @matchesDraw, matchesLost = @matchesLost, roundsWon = @roundsWon, roundsLost = @roundsLost, points = @points where teamID = @teamID");
                command.Parameters.Add(new SqlParameter("matchPlayed", t.matchesPlayed));
                command.Parameters.Add(new SqlParameter("matchesWon", t.matchesWon));
                command.Parameters.Add(new SqlParameter("matchesDraw", t.matchesDraw));
                command.Parameters.Add(new SqlParameter("matchesLost", t.matchesLost));
                command.Parameters.Add(new SqlParameter("roundsWon", t.roundsWon));
                command.Parameters.Add(new SqlParameter("roundsLost", t.roundsLost));
                command.Parameters.Add(new SqlParameter("points", t.points));
                command.Parameters.Add(new SqlParameter("teamID", t.teamID));

                db.InsertToTable(command);
            }
        }
    }
}
