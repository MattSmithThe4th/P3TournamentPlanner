using System;

namespace P3TournamentPlanner.Shared {
    public class Player {
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
        public Nullable<int> teamID { get; set; }
        private string _irlname;
        public string IRLName {
            get {
                return _irlname;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("IRLName cannot be null or an empty string");
                } else {
                    _irlname = value;
                }
            }
        }
        private string _igname;
        public string IGName {
            get {
                return _igname;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("IGName cannot be null or an empty string");
                } else {
                    _igname = value;
                }
            }
        }
        private string _steamid;
        public string steamID {
            get {
                return _steamid;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("SteamID cannot be null or an empty string");
                } else {
                    _steamid = value;
                }
            }
        }
        private string _csgorank;
        public string CSGORank {
            get {
                return _csgorank;
            }
            set {
                switch(value) {
                    case "Silver 1":
                        _csgorank = value;
                        break;
                    case "Silver 2":
                        _csgorank = value;
                        break;
                    case "Silver 3":
                        _csgorank = value;
                        break;
                    case "Silver 4":
                        _csgorank = value;
                        break;
                    case "Silver Elite":
                        _csgorank = value;
                        break;
                    case "Silver Elite Master":
                        _csgorank = value;
                        break;
                    case "Gold Nova 1":
                        _csgorank = value;
                        break;
                    case "Gold Nova 2":
                        _csgorank = value;
                        break;
                    case "Gold Nova 3":
                        _csgorank = value;
                        break;
                    case "Gold Nova Master":
                        _csgorank = value;
                        break;
                    case "Master Guardian 1":
                        _csgorank = value;
                        break;
                    case "Master Guardian 2":
                        _csgorank = value;
                        break;
                    case "Master Guardian Elite":
                        _csgorank = value;
                        break;
                    case "Distingquished Master Guardian":
                        _csgorank = value;
                        break;
                    case "Legendary Eagle":
                        _csgorank = value;
                        break;
                    case "Legendary Eagle Master":
                        _csgorank = value;
                        break;
                    case "Supreme Master First Class":
                        _csgorank = value;
                        break;
                    case "The Global Elite":
                        _csgorank = value;
                        break;
                    default:
                        throw new ArgumentException("Input is not a valid CSGO rank");
                }
            }
        }
        private int _playerskillrating;
        public int playerSkllRating { 
            get {
                return _playerskillrating;
            } set {
                if(value < 0) {
                    throw new ArgumentException("PlayerSkillRating cannot be less than 0");
                } else {
                    _playerskillrating = value;
                }
            }
        }
        private int _playerid;
        public int playerID { 
            get {
                return _playerid;
            } set {
                if(value < 1) {
                    throw new ArgumentException("playerId can not be less than 1");
                } else {
                    _playerid = value;
                }
            }
        }

        public Player(string IRLName, string IGName, string steamID, string CSGORank, int playerSkllRating) {
            this.IRLName = IRLName;
            this.IGName = IGName;
            this.steamID = steamID;
            this.CSGORank = CSGORank;
            this.playerSkllRating = playerSkllRating;
        }

        public Player() {
        }

        public Player(string iRLName, string iGName, string steamID, string cSGORank, int playerSkllRating, int playerID) : this(iRLName, iGName, steamID, cSGORank, playerSkllRating) {
            this.playerID = playerID;
        }

        public int CalculateSkillRating() {
            switch(this.CSGORank) {
                case "Silver 1":
                    return playerSkllRating = 4;

                case "Silver 2":
                    return playerSkllRating = 8;

                case "Silver 3":
                    return playerSkllRating = 12;

                case "Silver 4":
                    return playerSkllRating = 17;

                case "Silver Elite":
                    return playerSkllRating = 23;

                case "Silver Elite Master":
                    return playerSkllRating = 31;

                case "Gold Nova 1":
                    return playerSkllRating = 40;

                case "Gold Nova 2":
                    return playerSkllRating = 49;

                case "Gold Nova 3":
                    return playerSkllRating = 58;

                case "Gold Nova Master":
                    return playerSkllRating = 66;

                case "Master Guardian 1":
                    return playerSkllRating = 74;

                case "Master Guardian 2":
                    return playerSkllRating = 81;

                case "Master Guardian Elite":
                    return playerSkllRating = 86;

                case "Distingquished Master Guardian":
                    return playerSkllRating = 90;

                case "Legendary Eagle":
                    return playerSkllRating = 93;

                case "Legendary Eagle Master":
                    return playerSkllRating = 96;

                case "Supreme Master First Class":
                    return playerSkllRating = 99;

                case "The Global Elite":
                    return playerSkllRating = 100;

                default:
                    return 0;
            }
        }
    }
}
