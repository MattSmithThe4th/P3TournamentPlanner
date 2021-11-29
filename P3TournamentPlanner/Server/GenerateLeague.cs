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
        LigaerController ligaController = new LigaerController();

        List<int> teamIDs = new List<int>();
        List<Team> teams;
        List<Match> matches = new List<Match>();
        List<Division> divs = new List<Division>();


        /// <summary>
        /// Adds the ID of a team to a list used for generating divisions and matches in a league.
        /// </summary>
        /// <param name="teamID"></param>
        void OptIn(int teamID) {
            teamIDs.Add(teamID);
        }

        public void CreateLeague(int leagueID, DivisionFormat divFormat) {
            CreateDivision(leagueID, divFormat);
        }

        void CreateDivision(int leagueID, DivisionFormat divFormat) {
            DivisionController divcon = new DivisionController();
            teams = GrabTeam();

            foreach (Division div in divs) {
                List<Team> sortedTeamList = new List<Team>(); //ny liste af hold der kan sorteres efter teamranking
                List<int> sortedTeamIDs = new List<int>();

                //Tager kun holdene i den bestemte division
                foreach(Team team in teams) if (team.divisionID == div.divisionID) {
                        sortedTeamList.Add(team);
                }

                //Sorterer listen af hold i divisionen og tilføjer dem derefter til sorteret liste af IDer
                sortedTeamList.OrderBy(o => o.teamSkillRating).ToList();
                foreach (Team sortedTeam in sortedTeamList) {
                    sortedTeamIDs.Add(sortedTeam.teamID);
                }
                
                CreateMatches(div.divisionID, sortedTeamIDs);
                divcon.Post(div);
            }
            
        }

        void CreateMatches(int divID, List<int> teamIDs) {

        }

        List<Team> GrabTeam() {
            teams = new List<Team>();
            SingleTeamInformationController tc = new SingleTeamInformationController();
            foreach (int teamID in teamIDs) {
                teams.Add(tc.Get(teamID));
            }
            return teams;
        }


    }
}
