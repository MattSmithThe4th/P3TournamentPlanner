using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using P3TournamentPlanner.Shared;
using System.Data;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class TeamInformationController : ControllerBase {

        [HttpGet]
        public List<Team> Get()
        {
            Console.WriteLine("Get Received!----------------------------------------------------------------------------->");

            DatabaseQuerys db = new DatabaseQuerys();

            List<Team> teamList = new List<Team>();

            DataTable dt;
            DataTable dt2;

            dt = db.PullTable("select teamName, managerID, divisionID from TeamsDB");

            foreach (DataRow r in dt.Rows)
            {
                dt2 = db.PullTable($"select tlfNumber from ContactInfoDB where userID='{r[1]}'");
                DataRow r2 = dt2.Rows[0];
                Console.WriteLine((string)r2[0]);
                teamList.Add(new Team((string)r[0], (string)r2[0], (int)r[2]));
            }

            Console.WriteLine(dt);

            //Construct dem som objecter, og send listen afsted

            return teamList;
        }
    }
}