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
        [HttpGet("matches")]
        public List<Match> Get(int? division, int? teamID)
        {
            Console.WriteLine("Get Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();
            Console.WriteLine("div" + division);
            Console.WriteLine("team" + teamID);

            SqlCommand command = new SqlCommand();

            List<Match> matches = new List<Match>();
            List<Team> teams = new List<Team>();

            DataTable dt, teamTable;

            if (division != null && teamID == null)
            {
                command = new SqlCommand("select matchID, divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, " +
                    "startTime, playedFlag, hostClubID, serverIP, map from MatchDB where divisionID = @divisionID");
                command.Parameters.Add(new SqlParameter("divisionID", division));
            }
            else if (teamID != null && division == null)
            {
                command = new SqlCommand("select matchID, divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, " +
                    "startTime, playedFlag, hostClubID, serverIP, map from MatchDB where team1ID = @teamID or team2ID = @teamID");
                command.Parameters.Add(new SqlParameter("teamID", teamID));
            }

            dt = db.PullTable(command);

            foreach (DataRow r in dt.Rows)
            {
                command = new SqlCommand("select clubID, teamName from TeamsDB where teamID = @teamID");
                command.Parameters.Add(new SqlParameter("teamID", (int)r[3]));
                teamTable = db.PullTable(command);

                teams.Add(new Team((int)r[3], (int)teamTable.Rows[0][0], teamTable.Rows[0][1].ToString()));

                command = new SqlCommand("select clubID, teamName from TeamsDB where teamID = @teamID");
                command.Parameters.Add(new SqlParameter("teamID", (int)dt.Rows[0][4]));
                teamTable = db.PullTable(command);

                teams.Add(new Team((int)r[4], (int)teamTable.Rows[0][0], teamTable.Rows[0][1].ToString()));

                matches.Add(new Match((int)r[0], teams, r[7].ToString(), (int)r[8], (int)r[5], (int)r[6], (int)r[9], r[10].ToString(), r[11].ToString()));
            }
            return matches;
        }

        [HttpGet]
        public Match Get(int matchID)
        {
            Console.WriteLine("Get Recieved!" + matchID);

            DatabaseQuerys db = new DatabaseQuerys();

            Match match;
            List<Team> teams = new List<Team>();

            DataTable dt, teamTable;

            SqlCommand command = new SqlCommand("select matchID, divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, " +
                "startTime, playedFlag, hostClubID, serverIP, map from MatchDB where matchID = @matchID");
            command.Parameters.Add(new SqlParameter("matchID", matchID));

            dt = db.PullTable(command);

            Console.WriteLine(dt.Rows[0][3]);

            command = new SqlCommand("select clubID, teamName from TeamsDB where teamID = @teamID");
            command.Parameters.Add(new SqlParameter("teamID", (int)dt.Rows[0][3]));
            teamTable = db.PullTable(command);

            teams.Add(new Team((int)dt.Rows[0][3], (int)teamTable.Rows[0][0], teamTable.Rows[0][1].ToString()));

            command = new SqlCommand("select clubID, teamName from TeamsDB where teamID = @teamID");
            command.Parameters.Add(new SqlParameter("teamID", (int)dt.Rows[0][4]));
            teamTable = db.PullTable(command);

            teams.Add(new Team((int)dt.Rows[0][4], (int)teamTable.Rows[0][0], teamTable.Rows[0][1].ToString()));

            match = new Match((int)dt.Rows[0][0], teams, dt.Rows[0][7].ToString(), (int)dt.Rows[0][8], (int)dt.Rows[0][5], (int)dt.Rows[0][6], (int)dt.Rows[0][9], dt.Rows[0][10].ToString(), dt.Rows[0][11].ToString());

            Console.WriteLine(match.teams[0].teamName);

            return match;
        }

        [HttpPut]
        public void Put(Match match)
        {
            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("update MatchDB set" +
                " team1Score = @team1Score, team2Score = @team2Score, startTime = @startTime, playedFlag = @playedFlag, hostClubID = @hostClubID, serverIP = @serverIP, map = @map");

            command.Parameters.Add(new SqlParameter("team1Score", match.team1Score));
            command.Parameters.Add(new SqlParameter("team2Score", match.team2Score));
            command.Parameters.Add(new SqlParameter("startTime", match.startTime));
            command.Parameters.Add(new SqlParameter("playedFlag", match.playedFlag));
            command.Parameters.Add(new SqlParameter("hostClubID", match.clubHostID));
            command.Parameters.Add(new SqlParameter("serverIP", match.serverIP));
            command.Parameters.Add(new SqlParameter("map", match.map));

            db.InsertToTable(command);
        }
    }
}
