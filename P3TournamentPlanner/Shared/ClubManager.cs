using System;

namespace P3TournamentPlanner.Shared {
    public class ClubManager {
        //add login
        public Contactinfo contactinfo { get; set; }

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
        //Måske
        private string _userid;
        public string userID {
            get {
                return _userid;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("userID cannot be null or an empty string");
                } else {
                    _userid = value;
                }
            }
        }

        public ClubManager()
        {

        }
        public ClubManager(Contactinfo contactinfo, string userID, int clubID)
        {
            this.contactinfo = contactinfo;
            this.userID = userID;
            this.clubID = clubID;
        }

        public ClubManager(Contactinfo contactinfo, string userID) {
            this.contactinfo = contactinfo;
            this.userID = userID;
        }

        public ClubManager(Contactinfo contactinfo)
        {
            this.contactinfo = contactinfo;
        }
    }
}
