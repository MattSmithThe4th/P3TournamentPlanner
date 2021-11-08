using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Team {
        public int teamID { get; set; }
        public int clubID { get; set; }
        public int divisionID { get; set; }
        public int leagueID { get; set; }
        public string teamName { get; set; }
        public int teamRating { get; set; }
        public string contact { get; set; }
        public int roundsWon { get; set; }
        public int roundsLost { get; set; }
        public string managerID { get; set; }
        public int archiveFlag { get; set; }
        public int teamSkillRating { get; set; }

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
            this.teamRating = teamSkillRating;
            this.placement = placement;
            this.matchesPlayed = matchesPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }

        public Team(string name, string contact, int divisionID)
        {                   
            this.teamName = name;
            this.contact = contact;
            this.divisionID = divisionID;
        }
        // teamID, clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag
        public Team(int teamID, int clubID, int divisionID, int leagueID, string teamName, int teamRating, string contact, int placement, int matchPlayed, int matchesWon, int matchesDraw, int matchesLost, int roundsWon, int roundsLost, int points, string managerID, int archiveFlag) {
            this.teamID = teamID;
            this.clubID = clubID;
            this.divisionID = divisionID;
            this.leagueID = leagueID;
            this.teamName = teamName;
            this.teamRating = teamRating;
            this.contact = contact;
            this.roundsWon = roundsWon;
            this.roundsLost = roundsLost;
            this.managerID = managerID;
            this.archiveFlag = archiveFlag;
            this.placement = placement;
            this.matchesPlayed = matchPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }

        public Team(int teamID, int clubID, int divisionID, int leagueID, string name, int teamSkillRating, int placement, int matchPlayed,
        int matchesWon, int matchesDraw, int matchesLost, int roundsWon, int roundsLost, int points, string managerID, int archiveFlag)
        {
            this.teamID = teamID;
            this.clubID = clubID;
            this.divisionID = divisionID;
            this.leagueID = leagueID;
            this.teamName = name;
            this.teamSkillRating = teamSkillRating;
            this.placement = placement;
            this.matchesPlayed = matchPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.roundsWon = roundsWon;
            this.roundsLost = roundsLost;
            this.points = points;
            this.managerID = managerID;
            this.archiveFlag = archiveFlag;
        }
    }
}
