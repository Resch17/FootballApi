using FootballApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameSvc)
        {
            _gameService = gameSvc;
        }

        [HttpGet]
        public IActionResult GetAllGames(int week)
        {
            var games = _gameService.GetAllGamesByWeek(week);
            return Ok(games);
        }

    }
}
