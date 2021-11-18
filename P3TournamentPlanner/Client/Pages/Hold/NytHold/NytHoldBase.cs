using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P3TournamentPlanner.Shared;

namespace P3TournamentPlanner.Client.Pages.Hold
{
    public class NytHoldBase : ComponentBase
    {
        public Team team = new Team();
        public Player player = new Player();
        public List<Player> players = new List<Player>();

        public void AddPlayer()
        {
            players.Add(this.player);
            Console.WriteLine("");
            foreach (Player player in players)
            {
                Console.WriteLine(player.IRLName);
            }
            this.player = new Player();
            StateHasChanged();
        }
    }
}
