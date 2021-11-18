using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LiverpoolStatsApi.Services;
using LiverpoolStatsApi.Models;

namespace LiverpoolStatsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamSelectionController : ControllerBase
    {
        private readonly TeamSelectionService _teamselectionService;

        public TeamSelectionController(TeamSelectionService teamSelectionService)
        {
            _teamselectionService = teamSelectionService;
        }

        [HttpGet]
        public IEnumerable<TeamSelection> GetTeamSelections()
        {
            return _teamselectionService.GetTeamSelections();
        }

        [HttpPost]
        public ActionResult<TeamSelection> PostTeamSelection(TeamSelection newTeamSelection)
        {
            _teamselectionService.PostTeamSelection(newTeamSelection);
            return newTeamSelection;
        }

    }
}