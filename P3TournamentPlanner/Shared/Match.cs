using System.Collections.Generic;
using System;

namespace P3TournamentPlanner.Shared {
    public class Match
    {
        public int matchID { get; set; }
        public int divisionID { get; set; }
        public int leagueID { get; set; }
        public List<Team> teams { get; set; }
        public string startTime { get; set; }
        public int playedFlag { get; set; }
        public int resultTeam1 { get; set; }
        public int resultTeam2 { get; set; }
        public int clubHostID { get; set; }
        public string serverIP { get; set; }
        public string map { get; set; }
        public Match()
        {

        }
        public Match(int matchID, int divisionID, int leagueID, List<Team> teams, int resultTeam1, int resultTeam2, string startTime, int playedFlag, int clubHostID, string serverIP, string map)
        {
            this.matchID = matchID;
            this.divisionID = divisionID;
            this.leagueID = leagueID;
            this.teams = teams;
            this.resultTeam1 = resultTeam1;
            this.resultTeam2 = resultTeam2;
            this.startTime = startTime;
            this.playedFlag = playedFlag;
            this.resultTeam1 = resultTeam1;
            this.resultTeam2 = resultTeam2;
            this.clubHostID = clubHostID;
            this.serverIP = serverIP;
            this.map = map;
        }
    }
}
