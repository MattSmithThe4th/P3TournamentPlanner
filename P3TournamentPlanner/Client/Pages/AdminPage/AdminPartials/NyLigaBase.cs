using Microsoft.AspNetCore.Components;
using P3TournamentPlanner.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Client.Pages.AdminPage.AdminPartials {
    public class NyLigaBase : ComponentBase {
        [Parameter]
        public int leagueID { get; set; }

        public League liga = new League();

        public List<League> ligas = new List<League>();

    }
}
