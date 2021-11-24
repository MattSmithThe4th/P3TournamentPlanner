using System.Collections.Generic;
using System;

namespace P3TournamentPlanner.Shared {
    public class Match
    {
        public int leagueID { get; set; }
        public int divisionID { get; set; }
        public int matchID { get; set; }
        public List<Team> teams { get; set; }
        public string startTime { get; set; }
        public bool playedFlag { get; set; }
        public int team1Score { get; set; }
        public int team2Score { get; set; }
        public int clubHostID { get; set; }
        public string serverIP { get; set; }
        public string map { get; set; }

        public Match()
        {

        }

        //Bruges til rettelse af resultater af allerede spillet kamp
        public Match(int team1Score, int team2Score) {
            this.team1Score = team1Score;
            this.team2Score = team2Score;
        }

        public Match(int matchID, List<Team> teams, string startTime, bool playedFlag, int team1Score, int team2Score, int clubHostID, string serverIP, string map)
        {
            this.matchID = matchID;
            this.teams = teams;
            this.startTime = startTime;
            this.playedFlag = playedFlag;
            this.team1Score = team1Score;
            this.team2Score = team2Score;
            this.clubHostID = clubHostID;
            this.serverIP = serverIP;
            this.map = map;
        }

        public Match(List<Team> teams, string startTime, bool playedFlag, int clubHostID, string serverIP, string map, int team1Score, int team2Score) {
            this.teams = teams;
            this.startTime = startTime;
            this.playedFlag = playedFlag;
            this.clubHostID = clubHostID;
            this.serverIP = serverIP;
            this.map = map;
            this.team1Score = team1Score;
            this.team2Score = team2Score;
        }
    }
}
