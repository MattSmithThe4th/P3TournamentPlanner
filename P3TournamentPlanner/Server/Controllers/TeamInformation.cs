using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using P3TournamentPlanner.Shared;
using System.Data;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TeamInformationController : ControllerBase {

        [HttpGet]
        public List<Team> Get()
        {
            Console.WriteLine("Get Received!----------------------------------------------------------------------------->");

            DatabaseQuerys db = new DatabaseQuerys();

            List<Team> teamList = new List<Team>();

            DataTable dt;

            dt = db.PullTable("select teamName, managerTlf, divisionID from TeamsDB");

            foreach (DataRow r in dt.Rows)
            {
                teamList.Add(new Team((string)r[0], (string)r[1], (int)r[2]));
            }

            Console.WriteLine(dt);

            //Construct dem som objecter, og send listen afsted

            return teamList;
        }
    }
}