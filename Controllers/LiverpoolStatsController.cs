using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LiverpoolStatsApi.Models;
using LiverpoolStatsApi.Services;

namespace LiverpoolStatsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiverpoolStatsController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public LiverpoolStatsController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _playerService.Get();
        }
    }
}