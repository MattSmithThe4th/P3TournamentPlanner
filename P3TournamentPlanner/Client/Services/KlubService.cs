using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;
using P3TournamentPlanner.Shared;

namespace P3TournamentPlanner.Client.Services
{
    public class KlubService
    {
        public bool ValidateProduct(ClubManager clubManager)
        {
            PropertyInfo[] properties = typeof(ClubManager).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property != null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}
