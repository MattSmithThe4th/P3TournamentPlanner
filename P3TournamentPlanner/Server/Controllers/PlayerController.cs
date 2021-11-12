using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3TournamentPlanner.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

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

            SqlCommand command = new SqlCommand("select teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating from PlayerDB where teamID=@teamID and clubID = @clubID");
            command.Parameters.Add(new SqlParameter("teamID", teamID));
            command.Parameters.Add(new SqlParameter("clubID", clubID));

            dt = db.PullTable(command);

            //0teamID, 1clubID, 2IRLName, 3IGName, 4steamID, 5csgoRank

            foreach(DataRow r in dt.Rows) {
                playerList.Add(new Player((string)r[2], (string)r[3], (string)r[4], (string)r[5], (int)r[6]));

                //playerList.Add(new Player((int)r[1], (int)r[0], r[2].ToString(), r[3].ToString(), r[4].ToString(), r[5].ToString()));
            }

            foreach(Player p in playerList) {
                Console.WriteLine(p.IRLName);
            }

            return playerList;
        }

        [HttpPost]
        public void Post([FromBody]Player player, [FromHeader] int clubID, [FromHeader] int? teamID = null) {
            Console.WriteLine("Post Enter");

            DatabaseQuerys db = new DatabaseQuerys();

            Console.WriteLine("teamID: " + teamID);
            Console.WriteLine("clubID: " + clubID);

            SqlCommand command;

            if (teamID != null) {
                command = new SqlCommand("insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (@teamID, @clubID, @IRLName, @IGName, @steamID, @csgoRank, @skillRating)");
            } else {
                command = new SqlCommand("insert into PlayerDB(clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (@clubID, @IRLName, @IGName, @steamID, @csgoRank, @skillRating)");
            }


            if(teamID != null) command.Parameters.Add(new SqlParameter("teamID", teamID));
            command.Parameters.Add(new SqlParameter("clubID", clubID));
            command.Parameters.Add(new SqlParameter("IRLName", player.IRLName));
            command.Parameters.Add(new SqlParameter("IGName", player.IGName));
            command.Parameters.Add(new SqlParameter("steamID", player.steamID));
            command.Parameters.Add(new SqlParameter("csgoRank", player.CSGORank));
            command.Parameters.Add(new SqlParameter("skillRating", player.playerSkllRating));

            db.InsertToTable(command);
            
            Console.WriteLine("Post Done");
        }



    }
}
