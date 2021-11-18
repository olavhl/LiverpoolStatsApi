using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using LiverpoolStatsApi.Interfaces;
using System.Collections.Generic;

namespace LiverpoolStatsApi.Models
{
    public class TeamSelection : ITeamSelection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Player Goalkeeper { get; set; }
        public List<Player> Defenders { get; set; }
        public List<Player> Midfielders { get;  set;  }
        public List<Player> Attackers { get; set;  }
    }
}