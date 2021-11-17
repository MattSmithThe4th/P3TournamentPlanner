using P3TournamentPlanner.Server.Controllers;
using P3TournamentPlanner.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Server {
    public class GenerateLeague {
        int deadline { get; set; }
        League liga { get; set; }
        LigaerController ligaController = new LigaerController();

        List<int> teamIDs = new List<int>();
        List<Team> teams = new List<Team>();
        List<Match> matches = new List<Match>();
        List<Division> divs = new List<Division>();


        /// <summary>
        /// Adds the ID of a team to a list used for generating divisions and matches in a league.
        /// </summary>
        /// <param name="teamID"></param>
        void OptIn(int teamID) {
            teamIDs.Add(teamID);
        }

        void CreateLeague() {
            ligaController.Post(liga);

            CreateDivision();
        }

        void CreateDivision() {
            DivisionController divcon = new DivisionController();
            foreach (Division div in divs) {
                divcon.Post(div);
            }
            CreateMatches();
        }

        void CreateMatches() {

        }

        void GrabTeam() {
            SingleTeamInformationController tc = new SingleTeamInformationController();
            foreach (int teamID in teamIDs) {
                teams.Add(tc.Get(teamID));
            }
        }


    }
}
