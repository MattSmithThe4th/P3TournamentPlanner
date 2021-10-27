using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P3TournamentPlanner.Shared;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class StillingController : ControllerBase {

        [HttpGet]
        public List<Team> Get(string league, int division) {
            Console.WriteLine("Get Recieved!");
            Console.WriteLine("league: " + league);
            Console.WriteLine("division: " + division);
            List<Team> teamList = new List<Team>();
            //Læs parametre få at finde liga/division
            //Aflæs alle hold i denne division fra databasen
            //Construct dem som objecter, og send listen afsted
            // ----------- Mock Objects --------------
            teamList.Add(new Team("Team 1", 1, 5, 5, 0, 0, 15));
            teamList.Add(new Team("Team 2", 2, 5, 3, 1, 1, 10));
            teamList.Add(new Team("Team 3", 3, 5, 0, 1, 5, 1));

            // --------------- End --------------------

            foreach (Team t in teamList) {
                Console.WriteLine(t.name);
            }

            return teamList;
        }







    }
}
