using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Shared {
    public class Contactinfo {
        public Contactinfo() {

        }

        public Contactinfo(string userID, string name, string tlfNr, string discordID, string email) {
            this.userID = userID;
            this.name = name;
            this.tlfNr = tlfNr;
            this.discordID = discordID;
            this.email = email;
        }

        private string _userid;
        public string userID {
            get {
                return _userid;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("ContactInfo.userID cannot be null or an empty string");
                } else {
                    _userid = value;
                }
            }
        }
        private string _name;
        public string name {
            get {
                return _name;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("ContactInfo.Name cannot be null or an empty string");
                } else {
                    _name = value;
                }
            }
        }
        private string _tlfnr;
        public string tlfNr {
            get {
                return _tlfnr;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("ContactInfo.tlfNr cannot be null or an empty string");
                } else {
                    _tlfnr = value;
                }
            }
        }
        private string _discordid;
        public string discordID {
            get {
                return _discordid;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("ContactInfo.DiscordID cannot be null or an empty string");
                } else {
                    _discordid = value;
                }
            }
        }
        private string _email;
        public string email {
            get {
                return _email;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("ContactInfo.Email cannot be null or an empty string");
                } else {
                    _email = value;
                }
            }
        }
    }
}
