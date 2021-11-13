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
        public IEnumerable<Player> GetPlayers()
        {
            return _playerService.GetPlayers();
        }

        [HttpPost]
        public Player PostPlayer(Player newPlayer)
        {
            _playerService.PostPlayer(newPlayer);
            return newPlayer;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdatePlayer(string id, Player updatedPlayer)
        {
            var player = _playerService.GetPlayer(id);
            
            if (player == null) {
                return NotFound();
            }

            _playerService.UpdatePlayer(updatedPlayer);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var player = _playerService.GetPlayer(id);

            if (player == null)
            {
                return NotFound();
            }

            _playerService.RemovePlayer( player.Id );
            return NoContent();
        }
    }
}