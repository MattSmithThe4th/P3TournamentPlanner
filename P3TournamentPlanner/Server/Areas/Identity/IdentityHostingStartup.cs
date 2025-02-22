﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P3TournamentPlanner.Server.Data;
using P3TournamentPlanner.Server.Models;

[assembly: HostingStartup(typeof(P3TournamentPlanner.Server.Areas.Identity.IdentityHostingStartup))]
namespace P3TournamentPlanner.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}