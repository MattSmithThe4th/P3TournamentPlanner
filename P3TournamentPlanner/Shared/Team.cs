using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Team {
        public string name { get; set; }
        public List<Player> playerList { get; set; }
        public int teamSkillRating { get; set; }
        public ClubManager manager { get; set; }
        public string contact { get; set; }
        public int divisionID { get; set; }

        //stillings ting
        public int placement { get; set; }
        public int matchesPlayed { get; set; }
        public int matchesWon { get; set; }
        public int matchesDraw { get; set; }
        public int matchesLost { get; set; }
        public int points { get; set; }

        public Team(string name)
        {
            this.name = name;
        }
        public Team()
        {

        }

        public Team(string name, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points)
        {
            this.name = name;

            this.placement = placement;
            this.matchesPlayed = matchesPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }

        public Team(string name, List<Player> playerList, int teamSkillRating, ClubManager manager, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points) : this(name)
        {
            this.playerList = playerList;
            this.teamSkillRating = teamSkillRating;
            this.manager = manager;
            this.placement = placement;
            this.matchesPlayed = matchesPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }

        public Team(string name, string contact, int divisionID)
        {                   
            this.name = name;
            this.contact = contact;
            this.divisionID = divisionID;
        }
    }
}
