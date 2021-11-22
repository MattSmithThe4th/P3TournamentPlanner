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
    public class DivisionController : ControllerBase {
        [HttpGet]
        public List<Division> Get(int? leagueID) {
            Console.WriteLine("Get Recieved!");
            //Console.WriteLine("league: " + league);
            //Console.WriteLine("division: " + division);

            //SqlCommand command = new SqlCommand($"select tlfNumber from ContactInfoDB where userID=@userID");
            //command.Parameters.Add(new SqlParameter("userID", r[14]));
            //dt2 = db.PullTable(command);
            DatabaseQuerys db = new DatabaseQuerys();

            List<Division> divList = new List<Division>();
            
            DataTable dt;
            DivisionFormat df = new DivisionFormat();

            SqlCommand command = new SqlCommand();

            if (leagueID == null)
            {
                command = new SqlCommand($"select divisionID, leagueID, divisionFormat from DivisionsDB");
            }
            else
            {
                command = new SqlCommand($"select divisionID, leagueID, divisionFormat from DivisionsDB where leagueID = @leagueID");
                command.Parameters.Add(new SqlParameter("leagueID", leagueID));
            }

            
            dt = db.PullTable(command);
            //dt = db.PullTable($"select divisionID, leagueID, divisionFormat from DivisionsDB");
            
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
