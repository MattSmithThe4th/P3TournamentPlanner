namespace P3TournamentPlanner.Shared {
    public class Player {
        //public int clubID { get; set; }
        //public int teamID { get; set; }
        public string IRLName { get; set; }
        public string IGName { get; set; }
        public string steamID { get; set; }
        public string CSGORank { get; set; }
        public int playerSkllRating { get; set; }
        public int playerID { get; set; }

        public Player(string IRLName, string IGName, string steamID, string CSGORank, int playerSkllRating) {
            this.IRLName = IRLName;
            this.IGName = IGName;
            this.steamID = steamID;
            this.CSGORank = CSGORank;
            this.playerSkllRating = playerSkllRating;
        }

        public Player() {
        }
    }
}
