using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Team {
        public string name;
        public List<Player> playerList;
        public int teamSkillRating;
        public ClubManager manager;

        //stillings ting
        public int placement;
        public int matchesPlayed;
        public int matchesWon;
        public int matchesDraw;
        public int matchesLost;
        public int points;

        public Team(string name)
        {
            this.name = name;
        }

        public Team(string name, int placement, int matchesPlayed, int matchesWon, int matchesDraw, int matchesLost, int points) {
            this.name = name;

            this.placement = placement;
            this.matchesPlayed = matchesPlayed;
            this.matchesWon = matchesWon;
            this.matchesDraw = matchesDraw;
            this.matchesLost = matchesLost;
            this.points = points;
        }
        public string Navn { get; set; }
    }
}
