using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using P3TournamentPlanner.Shared;
using System.Data;
using Microsoft.Data.SqlClient;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TeamInformationController : ControllerBase {
        [HttpGet("team")]
        public Team Get(int teamID)
        {
            Console.WriteLine("Get Received!");

            DatabaseQuerys db = new DatabaseQuerys();

            DataTable dt;
            DataTable dt2;

            Team team = new Team();

            SqlCommand command;

            command = new SqlCommand("select teamID, clubID, teamName, managerID from TeamsDB where teamID = @teamID");
            command.Parameters.Add(new SqlParameter("teamID", teamID));


            dt = db.PullTable(command);

            //dt = db.PullTable("select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag from TeamsDB");
            //0teamID, 1clubID, 2divisionID, 3leagueID, 4teamName, 5teamRating, 6placement, 7matchPlayed, 8matchesWon, 9matchesDraw, 10matchesLost, 11roundsWon, 12roundsLost, 13points, 14managerID, 15archiveFlag
            foreach (DataRow r in dt.Rows)
            {

                command = new SqlCommand($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID=@userID");
                command.Parameters.Add(new SqlParameter("userID", r[3].ToString()));
                dt2 = db.PullTable(command);

                //DataRow r2 = dt2.Rows[0];
                //Console.WriteLine((string)r2[0]);
                //teamList.Add(new Team((int)r[0], (int)r[1], (int)r[2], (int)r[3], (string)r[4], (int)r[5], (string)r2[0], (int)r[6],
                //    (int)r[7], (int)r[8], (int)r[9], (int)r[10], (int)r[11], (int)r[12], (int)r[13], (string)r[14], (int)r[15]));

                Contactinfo contactInfo = new Contactinfo((string)dt2.Rows[0][0], (string)dt2.Rows[0][1], (string)dt2.Rows[0][2], (string)dt2.Rows[0][3]);
                ClubManager manager = new ClubManager(contactInfo, r[3].ToString());
                team = new Team((int)r[0], (int)r[1], r[2].ToString(), manager);

                Console.WriteLine("HEREEE:--->");
            }

            return team;
        }

        [HttpGet]
        public List<Team> Get(int? clubID, int? divisionID) {
            Console.WriteLine("Get Received!");

            DatabaseQuerys db = new DatabaseQuerys();

            List<Team> teamList = new List<Team>();

            DataTable dt;
            DataTable dt2;

            SqlCommand command = new SqlCommand();

            if(clubID == null && divisionID == null)
            {
                command = new SqlCommand("select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag from TeamsDB");
            }
            else if (clubID != null)
            {
                command = new SqlCommand("select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag from TeamsDB where clubID = @clubID");
                command.Parameters.Add(new SqlParameter("clubID", clubID));
            }
            else if (divisionID != null)
            {
                command = new SqlCommand("select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag from TeamsDB where divisionID = @divisionID");
                command.Parameters.Add(new SqlParameter("divisionID", divisionID));
            }

            dt = db.PullTable(command);

            //dt = db.PullTable("select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag from TeamsDB");
            //0teamID, 1clubID, 2divisionID, 3leagueID, 4teamName, 5teamRating, 6placement, 7matchPlayed, 8matchesWon, 9matchesDraw, 10matchesLost, 11roundsWon, 12roundsLost, 13points, 14managerID, 15archiveFlag
            foreach(DataRow r in dt.Rows) {

                command = new SqlCommand($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID=@userID");
                command.Parameters.Add(new SqlParameter("userID", r[14].ToString()));
                dt2 = db.PullTable(command);

                //DataRow r2 = dt2.Rows[0];
                //Console.WriteLine((string)r2[0]);
                //teamList.Add(new Team((int)r[0], (int)r[1], (int)r[2], (int)r[3], (string)r[4], (int)r[5], (string)r2[0], (int)r[6],
                //    (int)r[7], (int)r[8], (int)r[9], (int)r[10], (int)r[11], (int)r[12], (int)r[13], (string)r[14], (int)r[15]));

                Contactinfo contactInfo = new Contactinfo((string)dt2.Rows[0][0], (string)dt2.Rows[0][1], (string)dt2.Rows[0][2], (string)dt2.Rows[0][3]);
                ClubManager manager = new ClubManager(contactInfo, r[14].ToString());
                teamList.Add(new Team((int)r[0], (int)r[2], (int)r[3], (string)r[4], (int)r[5], (int)r[6], (int)r[7], (int)r[8], (int)r[9], (int)r[10], (int)r[11], (int)r[12], (int)r[13], manager, Convert.ToBoolean(r[15])));

                Console.WriteLine("HEREEE:--->" + (string)r[4]);
            }

            return teamList;
        }

        [HttpGet ("teamTest")]
        public List<Team> GetTeam(int? clubID, int? divisionID)
        {
            Console.WriteLine("Get Received!");

            DatabaseQuerys db = new DatabaseQuerys();

            List<Team> teamList = new List<Team>();

            DataTable dt;
            DataTable dt2;

            SqlCommand command = new SqlCommand();

            if (clubID == null && divisionID == null)
            {
                command = new SqlCommand("select teamID, clubID, teamName, managerID from TeamsDB");
            }
            else if (clubID != null)
            {
                command = new SqlCommand("select teamID, clubID, teamName, managerID from TeamsDB where clubID = @clubID");
                command.Parameters.Add(new SqlParameter("clubID", clubID));
            }
            else if (divisionID != null)
            {
                command = new SqlCommand("select teamID, clubID, teamName, managerID from TeamsDB where divisionID = @divisionID");
                command.Parameters.Add(new SqlParameter("divisionID", divisionID));
            }

            dt = db.PullTable(command);

            //dt = db.PullTable("select teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag from TeamsDB");
            //0teamID, 1clubID, 2divisionID, 3leagueID, 4teamName, 5teamRating, 6placement, 7matchPlayed, 8matchesWon, 9matchesDraw, 10matchesLost, 11roundsWon, 12roundsLost, 13points, 14managerID, 15archiveFlag
            foreach (DataRow r in dt.Rows)
            {

                command = new SqlCommand($"select contactName, tlfNumber, discordID, email from ContactInfoDB where userID=@userID");
                command.Parameters.Add(new SqlParameter("userID", r[3].ToString()));
                dt2 = db.PullTable(command);

                //DataRow r2 = dt2.Rows[0];
                //Console.WriteLine((string)r2[0]);
                //teamList.Add(new Team((int)r[0], (int)r[1], (int)r[2], (int)r[3], (string)r[4], (int)r[5], (string)r2[0], (int)r[6],
                //    (int)r[7], (int)r[8], (int)r[9], (int)r[10], (int)r[11], (int)r[12], (int)r[13], (string)r[14], (int)r[15]));

                Contactinfo contactInfo = new Contactinfo((string)dt2.Rows[0][0], (string)dt2.Rows[0][1], (string)dt2.Rows[0][2], (string)dt2.Rows[0][3]);
                ClubManager manager = new ClubManager(contactInfo, r[3].ToString());
                teamList.Add(new Team((int)r[0], (int)r[1], r[2].ToString(), manager));

                Console.WriteLine("HEREEE:--->");
            }

            return teamList;
        }

        [HttpPost]
        public void Post(Team team)
        {
            Console.WriteLine("Post Received!");

            DatabaseQuerys db = new DatabaseQuerys();
            DataTable dt;

            SqlCommand command = new SqlCommand("insert into TeamsDB(clubID, teamName, managerID) values(@clubID, @teamName, @managerID)");
            command.Parameters.Add(new SqlParameter("clubID", team.club.clubID));
            command.Parameters.Add(new SqlParameter("teamName", team.teamName));
            command.Parameters.Add(new SqlParameter("managerID", team.manager.userID));

            db.InsertToTable(command);

            command = new SqlCommand("select teamID from TeamsDB where teamName = @teamName");
            command.Parameters.Add(new SqlParameter("teamName", team.teamName));

            dt = db.PullTable(command);

            foreach (Player player in team.players)
            {
                command = new SqlCommand("insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values(@teamID, @clubID, @IRLname, @IGname, @steamID, @CSGOrank, @skillRating)");
                command.Parameters.Add(new SqlParameter("teamID", (int)dt.Rows[0][0]));
                command.Parameters.Add(new SqlParameter("clubID", team.club.clubID));
                command.Parameters.Add(new SqlParameter("IRLname", player.IRLName));
                command.Parameters.Add(new SqlParameter("IGname", player.IGName));
                command.Parameters.Add(new SqlParameter("steamID", player.steamID));
                command.Parameters.Add(new SqlParameter("CSGOrank", player.CSGORank));
                command.Parameters.Add(new SqlParameter("skillRating", player.CalculateSkillRating()));

                db.InsertToTable(command);
            }
        }
    }
}