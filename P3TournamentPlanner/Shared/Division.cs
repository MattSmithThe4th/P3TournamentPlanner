using System.Collections.Generic;
using System;

namespace P3TournamentPlanner.Shared {
    public class Division {
        public List<Team> teams { get; set; }
        public List<Match> matches { get; set; }
        public DivisionFormat divisionFormat { get; set; }
        private int _divisionid;
        public int divisionID {
            get {
                return _divisionid;
            } set { 
                if(value < 1) {
                    throw new ArgumentException("Division.DivisionID can not be less than 1");
                } else {
                    _divisionid = value;
                }
            }
        }
        private int _leagueid;
        public int leagueID { 
            get{
                return _leagueid;
            } set { 
                if(value < 1) {
                    throw new ArgumentException("Division.LeagueID can not be less than 1");
                } else {
                    _leagueid = value;
                }
            }
        }

        //Måske
        public bool archiveFlag { get; set; }

        public Division() { 
        
        }

        public Division(int divisionID, DivisionFormat divFormat) {
            this.divisionID = divisionID;
            divisionFormat = divFormat;
        }

        //THIS IS USED FOR TEST!!
        public Division(List<Team> teams, List<Match> matches) {
            this.teams = teams;
            this.matches = matches;
        }

        public Division(int divisionID, List<Team> teams) {
            this.divisionID = divisionID;
            this.teams = teams;
        }
    }
}
