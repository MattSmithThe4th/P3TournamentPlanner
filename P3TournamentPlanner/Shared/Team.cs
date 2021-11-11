using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Team {
        public int teamID { get; set; } 
        public int divisionID { get; set; }
        public string teamName { get; set; } 
        public int teamSkillRating { get; set; } 
        public ClubManager manager { get; set; } 
        public int roundsWon { get; set; } 
        public int roundsLost { get; set; } 
        public bool archiveFlag { get; set; }

        //stillings ting
        public int placement { get; set; } 
        public int matchesPlayed { get; set; } 
        public int matchesWon { get; set; } 
        public int matchesDraw { get; set; } 
        public int matchesLost { get; set; } 
        public int points { get; set; } 

        public Team(string name)
        {
            this.teamName = name;
        }
        public Team()
        {

        }

        public Team(int id)
        {
            teamID = id;
        }

        public Team(string name, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points)
        {
            this.teamName = name;

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

        public Team(string name, List<Player> playerList, int teamSkillRating, ClubManager manager, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points) : this(name)
        {
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
        public Team(int teamID, int divisionID, string teamName, int teamSkillRating, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int roundsWon, int roundsLost, int points, ClubManager manager, bool archiveFlag) {
            this.teamID = teamID;
            this.divisionID = divisionID;
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
    }
}
