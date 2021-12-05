using FootballApi.Models;
using System.Collections.Generic;

namespace FootballApi.Interfaces
{
    public interface ITeamService
    {
        List<Team> GetAllApiTeams();
    }
}