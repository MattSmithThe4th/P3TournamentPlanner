using System;
using System.Collections.Generic;

namespace P3TournamentPlanner.Shared {
    public class Club {

        private int _clubid;
        public int clubID { 
            get {
                return _clubid;
            }
            set {
                if(value < 1) {
                    throw new ArgumentException("ClubID can not be less than 1");
                } else {
                    _clubid = value;
                }
            } 
        }
        private string _name;
        public string name {
            get {
                return _name;
            } set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("Name cannot be null or an empty string");
                } else {
                    _name = value;
                }
            }
        }
        public List<Player> players { get; set; }
        public List<Team> teams { get; set; }
        public List<ClubManager> clubManagers { get; set; }
        private string _address;
        public string address {
            get {
                return _address;
            } set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("Address cannot be null or an empty string");
                } else {
                    _address = value;
                }
            }
        }
        public string base64Logo { get; set; }

        public Club() {
        }

        public Club(string name) {
            this.name = name;
        }

        public Club(int clubID, string name, string address, string base64Logo) {
            this.clubID = clubID;
            this.name = name;
            this.address = address;
            this.base64Logo = base64Logo;
        }

        public Club(int clubID)
        {
            this.clubID = clubID;
        }

        //Midlertidig
        public string ImageToBase64(string imgPath) {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

    }
}