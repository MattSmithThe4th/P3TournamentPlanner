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
    public class DivisionController : ControllerBase {
        public List<Division> Get() {
            Console.WriteLine("Get Recieved!");
            //Console.WriteLine("league: " + league);
            //Console.WriteLine("division: " + division);


            DatabaseQuerys db = new DatabaseQuerys();

            List<Division> divList = new List<Division>();
            

            DataTable dt;
            DivisionFormat df = new DivisionFormat();

            
            dt = db.PullTable($"select divisionID, leagueID, divisionFormat from DivisionsDB");
            
            foreach (DataRow r in dt.Rows) {
                df.format = r[2].ToString();
                divList.Add(new Division((int)r[0], df));
            }

            Console.WriteLine(dt);

            foreach (Division t in divList) {
                Console.WriteLine(t.divisionID);
            }

            return divList;
        }
    }
}
