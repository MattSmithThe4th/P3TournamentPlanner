namespace P3TournamentPlanner.Shared {
    public class Player {
        public int clubID { get; set; }
        public int teamID { get; set; }
        public string IRLName { get; set; }
        public string IGName { get; set; }
        public string steamID { get; set; }
        public string cssgoRank { get; set; }
        public int playerSkllRating;

        public Player(int clubID, int teamID, string IRLName, string IGName, string steamID, string cssgoRank) {
            this.clubID = clubID;
            this.teamID = teamID;
            this.IRLName = IRLName;
            this.IGName = IGName;
            this.steamID = steamID;
            this.cssgoRank = cssgoRank;
        }
    }
}
