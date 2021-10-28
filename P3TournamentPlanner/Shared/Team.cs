using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Shared
{
    public class Team
    {
        public Team(string navn)
        {
            Navn = navn;
        }
        public string Navn { get; set; }
    }
}
