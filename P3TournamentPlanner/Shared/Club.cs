using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Club {
        public string name { get; set; }
        public List<Player> players { get; set; }
        public List<ClubManager> clubManagers { get; set; }
        public string adress { get; set; }

        public Club() {
        }

        public Club(string name) {
            this.name = name;
        }

        //Midlertidig
        public string ImageToBase64(string imgPath) {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}