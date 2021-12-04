using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("getdivision")]
        public Division Get(int divisionID)
        {
            DatabaseQuerys db = new DatabaseQuerys();
            DataTable dt;
            Division division = new Division();
            DivisionFormat df = new DivisionFormat();
            SqlCommand command; ;

            command = new SqlCommand("select * from DivisionsDB where divisionID = @divisionID");
            command.Parameters.Add(new SqlParameter("divisionID", divisionID));
            dt = db.PullTable(command);

            df.format = dt.Rows[0][2].ToString();

            division.divisionID = (int)dt.Rows[0][0];
            division.leagueID = (int)dt.Rows[0][1];
            division.divisionFormat = df;
            division.archiveFlag = Convert.ToBoolean((int)dt.Rows[0][3]);

            return division;
        }

        [Authorize]
        [HttpPost]
        public void Post(Division division) {
            Console.WriteLine("Post Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("insert into divisionDB(divisionID, leagueID, divisionFormat) " +
                "values(@divisionID, @divisionLeagueID, @divisionFormat)");
            command.Parameters.Add(new SqlParameter("divisionID", division.divisionID));
            command.Parameters.Add(new SqlParameter("divisionLeagueID", division.leagueID));
            command.Parameters.Add(new SqlParameter("divisionFormat", division.divisionFormat));

            db.InsertToTable(command);
        }

        [Authorize]
        [HttpPut]
        public void Put(Division division, int divisionID) {
            Console.WriteLine("Put Recieved!");

            DatabaseQuerys db = new DatabaseQuerys();

            SqlCommand command = new SqlCommand("update DivisionsDB set divisionID = {@divisionleagueID}," +
                "divisionFormat = @divisionFormat where divisionID = @divisionID");
            command.Parameters.Add(new SqlParameter("divisionleagueID", division.leagueID));
            command.Parameters.Add(new SqlParameter("divisionFormat", division.divisionFormat));
            command.Parameters.Add(new SqlParameter("divisionID", divisionID));

            db.InsertToTable(command);
        }
    }
}
