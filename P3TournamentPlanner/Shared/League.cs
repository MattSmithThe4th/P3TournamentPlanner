using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class League {
        private string _name;
        public string name {
            get {
                return _name;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("League.Name cannot be null or an empty string");
                } else {
                    _name = value;
                }
            }
        }
        public List<Division> divisions { get; set; }
        //public List<SiteAdmin> admins { get; set; }
        public SiteAdmin admin { get; set; }
        public VideoGame game { get; set; }

        //Måske
        private int _leagueid;
        public int leagueID {
            get {
                return _leagueid;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("League.LeagueID can not be less than 1");
                } else {
                    _leagueid = value;
                }
            }
        }
        public bool archiveFlag { get; set; }
        private int _teamamount;
        public int teamAmount { 
            get {
                return _teamamount;
            } set {
                if(value < 0) {
                    throw new ArgumentException("League.teamAmount can not be less than 0");
                } else {
                    _teamamount = value;
                }
            }
        }




        public Club test { get; set; }

        public League() {
        }

        public League(string name) {
            this.name = name;
        }

        public League(string name, VideoGame game) {
            this.name = name;
            this.game = game;
        }

        public League(string name, SiteAdmin admin, VideoGame game, int leagueID, bool archiveFlag, int teamAmount) : this(name) {
            this.admin = admin;
            this.game = game;
            this.leagueID = leagueID;
            this.archiveFlag = archiveFlag;
            this.teamAmount = teamAmount;
        }

        //THIS IS USED FOR TEST!!
        public League(List<Division> divisions) {
            this.divisions = divisions;
        }
    }
}
