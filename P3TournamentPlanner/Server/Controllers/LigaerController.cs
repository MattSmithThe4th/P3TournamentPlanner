using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            dt = db.PullTable("select * from LeagueDB");

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

        [HttpPost]
        public void Post(League liga) {
            Console.WriteLine("Post Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            string command = $"insert into LeagueDB(leagueName, game, adminID, archiveFlag) values('{liga.name}, {liga.game}, {liga.admin}, {liga.archiveFlag}')";

            db.InsertToTable(command);
        }

        [HttpPut]
        public void Put(League liga, int leagueID) {
            Console.WriteLine("Put Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            string command = $"update LeagueDB set leagueName = {liga.name}, game = {liga.game}, adminID = {liga.admin}, archiveFlag = {liga.archiveFlag} where LeagueID = {leagueID}";

            db.InsertToTable(command);
        }
    }
}
