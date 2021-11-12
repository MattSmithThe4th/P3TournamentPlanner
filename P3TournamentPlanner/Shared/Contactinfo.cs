using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Shared {
    public class Contactinfo {
        public Contactinfo() {
        }

        public Contactinfo(string name, string tlfNr, string discordID, string email) {
            this.name = name;
            this.tlfNr = tlfNr;
            this.discordID = discordID;
            this.email = email;
        }

        public string name { set; get; }
        public string tlfNr { set; get; }
        public string discordID { set; get; }
        public string email { set; get; }
    }
}
