using System.Collections.Generic;
using System;

namespace P3TournamentPlanner.Shared {
    public class Match
    {
        public int matchID { get; set; }
        public List<Team> teams { get; set; }
        public string startTime { get; set; }
        public int playedFlag { get; set; }
        public string results { get; set; }
        public int clubHostID { get; set; }
        public string serverIP { get; set; }
        public string map { get; set; }

        public Match()
        {

        }

        public Match(int matchID, List<Team> teams, string startTime, int playedFlag, string results, int clubHostID, string serverIP, string map) {
            this.matchID = matchID;
            this.teams = teams;
            this.startTime = startTime;
            this.playedFlag = playedFlag;
            this.results = results;
            this.clubHostID = clubHostID;
            this.serverIP = serverIP;
            this.map = map;
        }
    }
}
