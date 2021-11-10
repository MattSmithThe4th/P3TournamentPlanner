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

            //Pulls from database, to .NET datatable
            SqlCommand command = new SqlCommand("select * from LeagueDB");
            dt = db.PullTable(command);
            //dt = db.PullTable("select * from LeagueDB");

            //Creates teamList, based on said data
            //INDEHOLDE MIDLERTIDIG FIX MED GAME, SOM VI SKAL FIXE SENERE :)
            foreach(DataRow r in dt.Rows) {
                if(r[1].ToString() == "CS:GO") {
                    leagueList.Add(new League(r[0].ToString(), new CSGO()));
                } else {
                    leagueList.Add(new League(r[0].ToString(), null));
                }
            }

            foreach(League l in leagueList) {
                Console.WriteLine(l.name);
            }

            return leagueList;
        }
    }
}
