using System.Collections.Generic;
using LiverpoolStatsApi.Models;

namespace LiverpoolStatsApi.Interfaces
{
    public interface ITeamSelection
    {
        string Id { get; set; }
        Player Goalkeeper { get; set; }
        List<Player> Defenders { get; set; }
        List<Player> Midfielders { get; set; }
        List<Player> Attackers { get; set; }
    
    }
}