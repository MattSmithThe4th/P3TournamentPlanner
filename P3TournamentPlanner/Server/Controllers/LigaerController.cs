﻿using Microsoft.AspNetCore.Authorization;
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
    public class LigaerController : ControllerBase {
        [HttpGet]
        public List<League> Get() {
            Console.WriteLine("League Get Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();
            List<League> leagueList = new List<League>();
            DataTable dt;
            int teamAmount = 0;

            //Pulls from database, to .NET datatable
            SqlCommand command = new SqlCommand("select * from LeagueDB");
            dt = db.PullTable(command);
            //dt = db.PullTable("select * from LeagueDB");

            //Creates teamList, based on said data
            //INDEHOLDE MIDLERTIDIG FIX MED GAME, SOM VI SKAL FIXE SENERE :)
            foreach(DataRow r in dt.Rows) {
                command = new SqlCommand($"select teamID from TeamsDB where leagueID = @leagueID");
                command.Parameters.Add(new SqlParameter("leagueID", r[0]));
                DataTable teamTable = db.PullTable(command);

                foreach(DataRow r2 in teamTable.Rows) {
                    teamAmount++;
                }

                command = new SqlCommand($"select * from ContactInfoDB where userID = @userID");
                command.Parameters.Add(new SqlParameter("userID", r[3]));
                DataTable ciTable = db.PullTable(command);

                Contactinfo ci = new Contactinfo((string)r[3], (string)ciTable.Rows[0][1], (string)ciTable.Rows[0][2], (string)ciTable.Rows[0][3], (string)ciTable.Rows[0][4]);
                SiteAdmin admin = new SiteAdmin(ci);

                if(r[2].ToString() == "CS:GO") {
                    leagueList.Add(new League((string)r[1], admin, new CSGO(), (int)r[0], Convert.ToBoolean(r[4]), teamAmount));
                    //leagueList.Add(new League(r[0].ToString(), new CSGO()));
                } else {
                    leagueList.Add(new League((string)r[1], admin, null, (int)r[0], Convert.ToBoolean(r[4]), teamAmount));
                }
            }

            foreach(League l in leagueList) {
                Console.WriteLine(l.name);
            }

            return leagueList;
        }

        [Authorize]
        [HttpPost]
        public void Post(League liga) {
            Console.WriteLine("Post Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            //string command = $"insert into LeagueDB(leagueName, game, adminID, archiveFlag) values('{liga.name}, {liga.game}, {liga.admin}, {liga.archiveFlag}')";
            
            SqlCommand command = new SqlCommand($"insert into LeagueDB(leagueName, game, adminID, archiveFlag) values(@name, @game, @admin, @flag)");
            command.Parameters.Add(new SqlParameter("name", liga.name));
            command.Parameters.Add(new SqlParameter("game", liga.game));
            command.Parameters.Add(new SqlParameter("admin", liga.admin));
            command.Parameters.Add(new SqlParameter("flag", liga.archiveFlag));

            db.InsertToTable(command);
        }

        [Authorize]
        [HttpPut]
        public void Put(League liga, int leagueID) {
            Console.WriteLine("Put Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            //string command = $"update LeagueDB set leagueName = {liga.name}, game = {liga.game}, adminID = {liga.admin}, archiveFlag = {liga.archiveFlag} where LeagueID = {leagueID}";
            SqlCommand command = new SqlCommand($"update LeagueDB set leagueName = @name, game = @game, adminID = @admin, archiveFlag = @flag where LeagueID = @leagueID");
            command.Parameters.Add(new SqlParameter("name", liga.name));
            command.Parameters.Add(new SqlParameter("game", liga.game));
            command.Parameters.Add(new SqlParameter("admin", liga.admin));
            command.Parameters.Add(new SqlParameter("flag", liga.archiveFlag));
            command.Parameters.Add(new SqlParameter("leagueID", leagueID));

            db.InsertToTable(command);
        }
    }
}
