using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Division {
        public List<Team> teams { get; set; }
        public List<Match> matches { get; set; }
        public DivisionFormat DivFormat { get; set; }
        public int DivID { get; set; }
        public string LeagueID { get; set; }



        public Division() { 
        
        }

        public Division(int divisionID, string leagueID, DivisionFormat divFormat) {
            DivID = divisionID;
            LeagueID = leagueID;
            DivFormat = divFormat;
        }
    }
}
