using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Match {
        public int matchID { get; set; }
        public int divisionID { get; set; }
        public int leagueID { get; set; }
        public List<Team> teams { get; set; }
        public string startTime { get; set; }
        public bool playedFlag { get; set; }
        public string results { get; set; }
        public int clubHostID { get; set; }
        public string serverIP { get; set; }

        public Match(int matchID, int divisionID, int leagueID, List<Team> teams, string startTime, bool playedFlag, int clubHostID, string serverIP) {
            this.matchID = matchID;
            this.divisionID = divisionID;
            this.leagueID = leagueID;
            this.teams = teams;
            this.startTime = startTime;
            this.playedFlag = playedFlag;
            this.clubHostID = clubHostID;
            this.serverIP = serverIP;
        }
    }
}
