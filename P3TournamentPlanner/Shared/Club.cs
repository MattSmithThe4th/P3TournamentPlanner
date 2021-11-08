using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Club {

        public string clubID { get; set; }
        public string name { get; set; }
        public List<Player> players { get; set; }
        public List<ClubManager> clubManagers { get; set; }
        public string address { get; set; }

        public Club() {
        }

        public Club(string name) {
            this.name = name;
        }

        public Club(string clubID, string name, string address) {
            this.clubID = clubID;
            this.name = name;
            this.address = address;
        }
    }
}