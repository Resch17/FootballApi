using FootballApi.Models;
using System.Collections.Generic;

namespace FootballApi.Interfaces
{
    public interface IGameService
    {
        List<Game> GetAllGamesByWeek(int week);
    }
}