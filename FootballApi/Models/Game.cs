using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Clock { get; set; }
        public int Quarter { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool Started { get; set; }
        public bool Completed { get; set; }
        public int WinnerId { get; set; }
    }
}
