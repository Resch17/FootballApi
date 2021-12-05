using FootballApi.Interfaces;
using FootballApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApi.Services
{
    public class TeamService : BaseService, ITeamService
    {
        public TeamService(IConfiguration configuration) : base(configuration) { }

        public List<Team> GetAllApiTeams()
        {
            List<Team> teams = new List<Team>();
            for (int i = 1; i < 35; i++)
            {
                var request = new RestRequest($"teams/{i}");
                var response = Client.Get(request);
                var content = response.Content;
                JObject jsonContent = JObject.Parse(content);
                JToken result = jsonContent["team"];
                Team team = result.ToObject<Team>();
                team.Logo = $"https://a.espncdn.com/i/teamlogos/nfl/500/{team.Abbreviation.ToLower()}.png";
                if (string.IsNullOrEmpty(team.Name))
                {
                    if (!string.IsNullOrEmpty(team.Location))
                    {
                        team.Name = "Football Team";
                    }

                    if (team.DisplayName == "Washington")
                    {
                        team.DisplayName = "Washington Football Team";
                    }
                }
                teams.Add(team);
            }

            return teams;
        }
    }
}
