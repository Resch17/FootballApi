using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApi.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Abbreviation { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
