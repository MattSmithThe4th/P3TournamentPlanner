using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using P3TournamentPlanner.Server.Data;
using P3TournamentPlanner.Server.Models;
using P3TournamentPlanner.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P3TournamentPlanner.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private List<ApplicationUser> appUserList;
        private List<User> userList = new List<User>();

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet("users")]
        public List<User> GetUsersAsync() {
            //List<ApplicationUser> appUserList = userManager.Users.ToList<ApplicationUser>();
            appUserList = userManager.Users.ToList<ApplicationUser>();

            Console.WriteLine("bling blong");
            UpdateUserListAsync().Wait();
            Console.WriteLine("dinmor");

            return userList;
        }

        [HttpPost("genMatches")]
        public League GenerateMatches([FromBody] League league) {
            Random rand = new Random();

            foreach(Division division in league.divisions) {
                for(int i = 0; i < division.teams.Count - 1; i++) {
                    for(int j = i + 1; j < division.teams.Count; j++) {
                        List<Team> teamsInMatch = new List<Team>();
                        teamsInMatch.Add(division.teams[i]);
                        teamsInMatch.Add(division.teams[j]);

                        division.matches.Add(new Match(teamsInMatch, "This is the start time", 0, teamsInMatch[rand.Next(0, 2)].clubID, "This is the ServerIP", "This is the map", 0, 0));
                    }
                }
            }

            return league;
        }

        [HttpPost("genDivisions")]
        public List<Division> GenerateDivisions([FromBody] List<Team> teamList, [FromHeader] int divisionAmount) {
            List<Division> divisions = new List<Division>();

            int teamsLeft = teamList.Count();

            foreach(Team t in teamList) {
                Console.WriteLine(t.teamName);
            }

            for(int i = 0; i < divisionAmount; i++) {
                divisions.Add(new Division(new List<Team>()));
                Console.WriteLine("Teams left pre: " + teamsLeft);
                Console.WriteLine($"Division left pre: {divisionAmount - i}");
                Console.WriteLine($"There are {Math.Ceiling(((float)teamsLeft / ((float)divisionAmount - i)))} teams in division {i + 1}");
                for(int j = 0; j < Math.Ceiling(((float)teamsLeft / ((float)divisionAmount - i))); j++) {
                    Console.WriteLine(teamList[teamsLeft - 1 - j].teamName);
                    divisions[i].teams.Add(teamList[teamsLeft - 1 - j]);
                }

                teamsLeft -= (int)Math.Ceiling(((float)teamsLeft / ((float)divisionAmount - i)));
                Console.WriteLine("");
            }

            return divisions;
        }


        [HttpPost("changeRole")]
        public async Task PostRole([FromBody] User user, [FromHeader] bool toBecomeAdmin) {
            Console.WriteLine("PUT ENTERED!!!!!!!");

            Console.WriteLine("bool: " + toBecomeAdmin);

            Console.WriteLine("USERID!!!: " + user.ID);
            
            ApplicationUser appUser = await userManager.FindByIdAsync(user.ID);

            if(toBecomeAdmin) {
                await userManager.AddToRoleAsync(appUser, "Administrator");
            } else {
                await userManager.RemoveFromRoleAsync(appUser, "Administrator");
            }
        }

        public async Task UpdateUserListAsync() {
            foreach(ApplicationUser appUser in appUserList) {
                List<string> rolesList = new List<string>();
                var roles = await userManager.GetRolesAsync(appUser);
                foreach(var role in roles) {
                    Console.WriteLine("Lookie: " + role.ToString());
                    rolesList.Add(role.ToString());
                }
                userList.Add(new User(appUser.Id, appUser.UserName, rolesList));
            }
        }

    }
}
