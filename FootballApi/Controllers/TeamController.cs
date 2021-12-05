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
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamService _teamService;

        public TeamController(ITeamRepository teamRepo, ITeamService teamSvc)
        {
            _teamRepository = teamRepo;
            _teamService = teamSvc;
        }

        [HttpPost("syncTeams")]
        public IActionResult SyncTeams(string input)
        {
            if (input != "A") return BadRequest();
            _teamRepository.DeleteAllTeams();
            var teams = _teamService.GetAllApiTeams();
            foreach (var team in teams)
            {
                if (team.DisplayName == "NFC") continue;
                if (team.DisplayName == "AFC") continue;
                _teamRepository.InsertTeam(team);
            }
            return Ok();
        }
    }
}
