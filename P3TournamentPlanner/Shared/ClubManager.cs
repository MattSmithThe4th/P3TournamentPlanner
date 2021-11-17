namespace P3TournamentPlanner.Shared {
    public class ClubManager {
        //add login
        public Contactinfo contactinfo { get; set; }

        public int ClubID { get; set; }
        //Måske
        public string userID { get; set; }

        public ClubManager()
        {

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
