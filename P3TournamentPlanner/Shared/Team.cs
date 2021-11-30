using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Team {
        public int teamID { get; set; }
        public int clubID { get; set; }
        public int divisionID { get; set; }
        public int leagueID { get; set; }
        public string teamName { get; set; }
        public int teamSkillRating { get; set; }
        public ClubManager manager { get; set; }
        public Club club { get; set; }
        public List<Player> players = new List<Player>();
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
