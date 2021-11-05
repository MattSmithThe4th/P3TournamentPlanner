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
    public class PlayerController : ControllerBase {


        [HttpGet]
        public List<Player> Get(int teamID, int clubID) {
            Console.WriteLine("Player Get Recieved!");
            Console.WriteLine("teamID" + teamID);
            Console.WriteLine("clubID" + clubID);

            DatabaseQuerys db = new DatabaseQuerys();
            List<Player> playerList = new List<Player>();
            DataTable dt;

            dt = db.PullTable("select teamID, clubID, IRLName, IGName, steamID, csgoRank from PlayerDB where teamID=" + teamID + " and clubID=" + clubID);

            foreach(DataRow r in dt.Rows) {
                playerList.Add(new Player((int)r[1], (int)r[0], r[2].ToString(), r[3].ToString(), r[4].ToString(), r[5].ToString()));
            }

            foreach(Player p in playerList) {
                Console.WriteLine(p.IRLName);
            }

            return playerList;
        }




    }
}
