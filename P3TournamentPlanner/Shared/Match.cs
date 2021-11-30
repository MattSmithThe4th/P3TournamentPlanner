using System.Collections.Generic;
using System;

namespace P3TournamentPlanner.Shared {
    public class Match
    {
        private int _leagueid;
        public int leagueID {
            get {
                return _leagueid;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("LeagueID can not be less than 1");
                } else {
                    _leagueid = value;
                }
            }
        }
        private int _divisionid;
        public int divisionID {
            get {
                return _divisionid;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("DivisionID can not be less than 1");
                } else {
                    _divisionid = value;
                }
            }
        }
        private int _matchid;
        public int matchID { 
            get {
                return _matchid;
            } set {
                if(value < 1) {
                    throw new ArgumentException("matchID can not be less than 1");
                } else {
                    _matchid = value;
                }
            }
        }
        public List<Team> teams { get; set; }
        public string startTime { get; set; }
        public bool playedFlag { get; set; }
        private int _team1score;
        public int team1Score {
            get {
                return _team1score;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("team1Score cannot be less than 0");
                } else {
                    _team1score = value;
                }
            }
        }
        private int _team2score;
        public int team2Score {
            get {
                return _team2score;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("team2Score cannot be less than 0");
                } else {
                    _team2score = value;
                }
            }
        }
        private int _clubhostid;
        public int clubHostID {
            get {
                return _clubhostid;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("clubHostID cannot be less than 1");
                } else {
                    _clubhostid = value;
                }
            }
        }
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

        public Match(int leagueID, int divisionID, int matchID, List<Team> teams, string startTime, bool playedFlag, int team1Score, int team2Score, int clubHostID, string serverIP, string map) : this(leagueID, divisionID)
        {
            this.leagueID = leagueID;
            this.divisionID = divisionID;
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
    }
}
