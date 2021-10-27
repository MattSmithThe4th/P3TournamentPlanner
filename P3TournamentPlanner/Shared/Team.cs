using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Team {
        public string name;
        public List<Player> playerList;
        public int teamSkillRating;
        public int placement;
        public ClubManager clubManager;
    }
}
