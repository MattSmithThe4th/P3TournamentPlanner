﻿using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Division {
        public List<Team> teams { get; set; }
        public List<Match> matches { get; set; }
        public DivisionFormat divisionFormat { get; set; }
        public int divisionID { get; set; }
        public int leagueID { get; set; }

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

        public Division(List<Team> teams) {
            this.teams = teams;
        }
    }
}
