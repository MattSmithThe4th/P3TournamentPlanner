using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Team {
        private int _teamid;
        public int teamID {
            get {
                return _teamid;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("Team.TeamID can not be less than 1");
                } else {
                    _teamid = value;
                }
            }
        }
        private int _clubid;
        public int clubID {
            get {
                return _clubid;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("Team.ClubID can not be less than 1");
                } else {
                    _clubid = value;
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
                    throw new ArgumentException("Team.DivisionID can not be less than 1");
                } else {
                    _divisionid = value;
                }
            }
        }
        private int _leagueid;
        public int leagueID {
            get {
                return _leagueid;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("Team.LeagueID can not be less than 1");
                } else {
                    _leagueid = value;
                }
            }
        }
        private string _teamname;
        public string teamName {
            get {
                return _teamname;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("Team.TeamName cannot be null or an empty string");
                } else {
                    _teamname = value;
                }
            }
        }
        private int _teamskillrating;
        public int teamSkillRating {
            get {
                return _teamskillrating;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("Team.TeamSkillRating cannot be less than 0");
                } else {
                    _teamskillrating = value;
                }
            }
        }
        public ClubManager manager { get; set; }
        public Club club { get; set; }
        public List<Player> players = new List<Player>();
        private int _roundswon;
        public int roundsWon {
            get {
                return _roundswon;
            } set {
                if(value < 0) {
                    throw new ArgumentException("Team.RoundsWon cannot be less than 0");
                } else {
                    _roundswon = value;
                }
            }
        }
        private int _roundslost;
        public int roundsLost {
            get {
                return _roundslost;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("Team.RoundsLost cannot be less than 0");
                } else {
                    _roundslost = value;
                }
            }
        }
        public bool archiveFlag { get; set; }

        //stillings ting
        private int _placement;
        public int placement {
            get {
                return _placement;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("Team.Placement can not be less than 1");
                } else {
                    _placement = value;
                }
            }
        }
        private int _matchesplayed;
        public int matchesPlayed {
            get {
                return _matchesplayed;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("Team.MatchesPlayed can not be less than 1");
                } else {
                    _matchesplayed = value;
                }
            }
        }
        private int _matcheswon;
        public int matchesWon {
            get {
                return _matcheswon;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("Team.MatchesWon can not be less than 1");
                } else {
                    _matcheswon = value;
                }
            }
        }
        private int _matchesdraw;
        public int matchesDraw {
            get {
                return _matchesdraw;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("Team.MatchesDraw can not be less than 1");
                } else {
                    _matchesdraw = value;
                }
            }
        }
        private int _matcheslost;
        public int matchesLost {
            get {
                return _matcheslost;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("Team.MatchesLost can not be less than 1");
                } else {
                    _matcheslost = value;
                }
            }
        }
        private int _points;
        public int points {
            get {
                return _points;
            }
            set {
                if(value < 0) {
                    throw new ArgumentException("Team.Points can not be less than 1");
                } else {
                    _points = value;
                }
            }
        }

        public Team(string name) {
            this.teamName = name;
        }
        public Team() {

        }

        public Team(int clubID, string name, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points) {
            this.teamName = name;
            this.clubID = clubID;
            this.placement = placement;
            this.matchesPlayed = matchesPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }

        //public Team(string name, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points, ClubManager manager) {
        //    this.teamName = name;

        //    this.managerID = manager;
        //    this.placement = placement;
        //    this.matchesPlayed = matchesPlayed;
        //    this.matchesWon = matchesWon;
        //    this.matchesDraw = matchesDraw;
        //    this.matchesLost = matchesLost;
        //    this.points = points;
        //}

        public Team(string name, List<Player> playerList, int teamSkillRating, ClubManager manager, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points) : this(name) {
            this.teamSkillRating = teamSkillRating;
            this.manager = manager;
            this.placement = placement;
            this.matchesPlayed = matchesPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }

        // teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag
        public Team(int teamID, int clubID, int divisionID, int leagueID, string teamName, int teamSkillRating, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int roundsWon, int roundsLost, int points, ClubManager manager, bool archiveFlag) {
            this.teamID = teamID;
            this.clubID = clubID;
            this.divisionID = divisionID;
            this.leagueID = leagueID;
            this.teamName = teamName;
            this.teamSkillRating = teamSkillRating;
            this.manager = manager;
            this.roundsWon = roundsWon;
            this.roundsLost = roundsLost;
            this.archiveFlag = archiveFlag;
            this.placement = placement;
            this.matchesPlayed = matchesPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }

        public Team(int teamID, int clubID, string teamName)
        {
            this.teamID = teamID;
            this.clubID = clubID;
            this.teamName = teamName;
        }

        public Team(ClubManager manager, Club club, List<Player> players) {
            this.manager = manager;
            this.club = club;
            this.players = players;
        }

        public Team(Club club) {
            this.club = club;
        }

        public Team(int teamID, int clubID, string teamName, ClubManager clubManager) {
            this.teamID = teamID;
            this.club = new Club(clubID);
            this.teamName = teamName;
            this.manager = clubManager;
        }

        

        //THIS IS USED FOR TEST!!
        public Team(int clubID, string teamName) {
            this.clubID = clubID;
            this.teamName = teamName;
        }

        //constructor for updating teamDB after game results come in
        public Team(int teamID, int roundsWon, int roundsLost, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points) {
            this.teamID = teamID;
            this.roundsWon = roundsWon;
            this.roundsLost = roundsLost;
            this.placement = placement;
            this.matchesPlayed = matchesPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }

        //Used in genMatches
        public Team(int teamID, int clubID, int divisionID, int leagueID, string teamName, int teamSkillRating, ClubManager manager) {
            this.teamID = teamID;
            this.clubID = clubID;
            this.divisionID = divisionID;
            this.leagueID = leagueID;
            this.teamName = teamName;
            this.teamSkillRating = teamSkillRating;
            this.manager = manager;
        }

        //den nemme løsning. hvis vi vil være fancy kan vi lave et weighted system
        private int calculateTeamSkillRating(List<Player> players) {
            int rating = 0;
            foreach(Player p in players) {
                rating += p.playerSkllRating;
            }

            return rating;
        }


    }
}
