using FootballApi.Models;

namespace FootballApi.Interfaces
{
    public interface ITeamRepository
    {
        void DeleteAllTeams();
        void InsertTeam(Team team);
    }
}