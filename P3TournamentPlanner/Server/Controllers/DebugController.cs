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
    public class DebugController : ControllerBase {

        [HttpGet]
        public DebugObject Get() {
            //DETTE ER DEBUG PLEASE FUCKING SLET
            Console.WriteLine("Start of Debug Shit");

            Club debugClub = new Club();
            string base64String;

            base64String = debugClub.ImageToBase64(@"C:\Users\Emil\Desktop\xd\HobroVikings.png");

            DatabaseQuerys debugDB = new DatabaseQuerys();
            DataTable debugTable = new DataTable();

            //debugDB.InsertToTable($"insert into ClubDB(clubName, clubAddress, clubDescription, clubLogo) values ('Dall Villaby', 'Klokkevej 49, 9230 Svenstrup J', 'Dall Villaby er en esports organisation, som spiller computer og sådan noget. De har en træner som hedder Stålkat, hvilket er ret dope navn.', '{base64String}')");

            debugTable = debugDB.PullTable("select clubLogo from ClubDB where clubID = 5");

            //Console.WriteLine(debugTable.Rows[0][0].ToString());
            Console.WriteLine("End of Debug Shit");

            DebugObject DO = new DebugObject(debugTable.Rows[0][0].ToString());


            //DETTE ER SLUTNINGNE PÅ DEBUG SHIT



            return DO;
        }
    }
}
