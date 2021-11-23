using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Shared {
    public class Contactinfo {
        public Contactinfo() {

        }

        public Contactinfo(string userID, string contactName, string tlfNumber, string discordID, string email) {
            this.userID = 
            this.contactName = contactName;
            this.tlfNumber = tlfNumber;
            this.discordID = discordID;
            this.email = email;
        }

        public string userID { get; set; }
        public string contactName { set; get; }
        public string tlfNumber { set; get; }
        public string discordID { set; get; }
        public string email { set; get; }
    }
}
