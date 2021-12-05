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
    public class GameService : BaseService, IGameService
    {
        public GameService(IConfiguration configuration) : base(configuration) { }

        public List<Game> GetAllGamesByWeek(int week)
        {
            List<Game> games = new List<Game>();
            var request = new RestRequest($"scoreboard?week={week}", DataFormat.Json);
            var response = Client.Get(request);
            var content = response.Content;
            JObject jsonContent = JObject.Parse(content);
            var evts = jsonContent["events"].Children().ToList();

            foreach (var evt in evts)
            {
                Game game = new Game()
                {
                    Id = int.Parse(evt["id"].ToString()),
                    Clock = evt["status"]["displayClock"].ToString(),
                    Quarter = int.Parse(evt["status"]["period"].ToString()),
                    Venue = evt["competitions"][0]["venue"]["fullName"].ToString(),
                    Date = DateTime.Parse(evt["competitions"][0]["date"].ToString()),
                    Started = evt["status"]["type"]["state"].ToString() != "pre",
                    Completed = bool.Parse(evt["status"]["type"]["completed"].ToString())
                };
                var evtTeams = evt["competitions"][0]["competitors"].ToList();
                var homeEvtTeam = evtTeams.Find(t => t["homeAway"].ToString() == "home");
                var awayEvtTeam = evtTeams.Find(t => t["homeAway"].ToString() == "away");

                if (game.Completed)
                {
                    try
                    {
                        var winner = evtTeams.Find(t => bool.Parse(t["winner"].ToString()));
                        game.WinnerId = winner != null ? int.Parse(winner["id"].ToString()) : 0;
                    }
                    catch
                    {
                        game.WinnerId = 0;
                    }
                } else
                {
                    game.WinnerId = 0;
                }

                game.HomeScore = int.Parse(homeEvtTeam["score"].ToString());
                game.AwayScore = int.Parse(awayEvtTeam["score"].ToString());

                game.HomeTeam = homeEvtTeam["team"].ToObject<Team>();
                game.AwayTeam = awayEvtTeam["team"].ToObject<Team>();



                games.Add(game);
            }



            return games;
        }
    }
}
