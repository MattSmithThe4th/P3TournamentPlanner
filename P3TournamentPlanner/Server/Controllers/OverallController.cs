using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using P3TournamentPlanner.Shared;
using System.Data;
using Microsoft.Data.SqlClient;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OverallController : ControllerBase {
        List<T> CreateList<T>(SqlCommand command) {
            DatabaseQuerys db = new DatabaseQuerys();
            DataTable dt;
            List<T> result = new List<T>();
            //command.Parameters.Add(new SqlParameter("div", division))
            dt = db.PullTable(command);

            var fields = typeof(T).GetFields();

            foreach (DataRow r in dt.Rows) {

                var obj = Activator.CreateInstance<T>();
                foreach (var fieldInfo in fields) {

                    foreach (DataColumn c in dt.Columns) {
                        if (fieldInfo.Name == c.ColumnName) {
                            object v;

                            if (c.ColumnName == "team1ID" || c.ColumnName == "team2ID") {
                                command = new SqlCommand($"select * from TeamsDB where teamID = @teamID");
                                command.Parameters.Add(new SqlParameter("teamID", (int)r[c.ColumnName]));
                                v = CreateList<Team>(command);
                            }
                            else if (c.ColumnName == "managerID") { //clubmanager og contactinfo skal indsættes ordenligt
                                command = new SqlCommand($"select * from ContactInfoDB where userID = @userID");
                                command.Parameters.Add(new SqlParameter("userID", (int)r[c.ColumnName]));
                                v = CreateList<ClubManager>(command);
                            }
                            else {
                                v = r[c.ColumnName];
                            }
                            v = r[c.ColumnName];
                            fieldInfo.SetValue(obj, v);
                        }
                    }
                }
                result.Add(obj);
            }
            return result;
        }

        [HttpGet]
        public List<T> Get<T>(/*string commandText*/) where T: class { //Fejlen sker pga. metoden er generic
            Console.WriteLine("Get Recieved!");
            //List<T> list = new List<T>();

            //SqlCommand command = new SqlCommand(commandText);
            SqlCommand command = new SqlCommand($"select * from TeamDB");

            //Type d1 = typeof(List<>);
            //Type[] typeArgs = { typeof(T) };
            //Type constructed = d1.MakeGenericType(typeArgs);
            //object o = Activator.CreateInstance(constructed);

            return CreateList<T>(command);
        }
    }
}




    //[HttpGet]
    //public List<T> Get<T>() {
    //    Console.WriteLine("Get Recieved!");

    //    //Console.WriteLine("Match ID: " + matchID.GetValueOrDefault());


    //    DatabaseQuerys db = new DatabaseQuerys();
    //    List<T> list = new List<T>();



    //    DataTable table, teamTable, contactTable;

    //    SqlCommand command = new SqlCommand($"select * from MatchDB where divisionID = @div");
    //    //command.Parameters.Add(new SqlParameter("div", division));

    //    table = db.PullTable(command);

    //    //table = db.PullTable($"select matchID, divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, " +
    //    //    $"startTime, playedFlag, hostClubID, serverIP, map from MatchDB where divisionID = " + division);

    //    list = CreateList<T>()

    //    foreach (DataRow r in table.Rows) {
    //        List<Team> teamList = new List<Team>();
    //        for (int i = 0; i < 2; i++) {
    //            command = new SqlCommand($"select * from TeamsDB where teamID = @teamID");
    //            command.Parameters.Add(new SqlParameter("teamID", (int)r[3 + i]));
    //            teamTable = db.PullTable(command);

    //            foreach (DataRow row in teamTable.Rows) {
    //                command = new SqlCommand($"select * from ContactInfoDB where userID = @userID");
    //                command.Parameters.Add(new SqlParameter("userID", row[14]));
    //                contactTable = db.PullTable(command);

    //                Contactinfo contactInfo = new Contactinfo((string)contactTable.Rows[0][0], (string)contactTable.Rows[0][1], (string)contactTable.Rows[0][2], (string)contactTable.Rows[0][3]);
    //                ClubManager manager = new ClubManager(contactInfo, (string)row[14]);
    //                teamList.Add(new Team((int)row[0], (int)row[1], (int)row[2], (int)row[3], (string)row[4], (int)row[5], (int)row[6], (int)row[7], (int)row[8], (int)row[9], (int)row[10], (int)row[11], (int)row[12], (int)row[13], manager, Convert.ToBoolean(row[15])));
    //            }

    //        }

    //        //"0matchID, 1divisionID, 2leagueID, 3team1ID, 4team2ID, 5team1Score, 6team2Score, 7startTime, 8playedFlag, 9hostClubID, 10serverIP, 11map"

    //        list.Add((T)(object)new Match((int)r[0], teamList, (string)r[7], (int)r[8], (int)r[5], (int)r[6], (int)r[9], (string)r[10], (string)r[11]));
    //        }

    //    Console.WriteLine(table);

    //    return list;
    //}
