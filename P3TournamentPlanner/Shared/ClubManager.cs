namespace P3TournamentPlanner.Shared {
    public class ClubManager {
        //add login
        public Contactinfo contactinfo { get; set; }

        public string testString { get; set; }
        public int testInt { get; set; }

        public ClubManager(string testString, int testInt) {
            this.testString = testString;
            this.testInt = testInt;
        }
    }
}
