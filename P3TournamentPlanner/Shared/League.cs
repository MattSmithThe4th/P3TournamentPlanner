using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class League {
        public string name { get; set; }
        public List<Division> divisions { get; set; }
        //public List<SiteAdmin> admins { get; set; }
        public SiteAdmin admin { get; set; }
        public VideoGame game { get; set; }

        //Måske
        public int leageID { get; set; }
        public bool archiveFlag { get; set; }




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
    }
}
