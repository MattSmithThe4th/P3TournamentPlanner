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
