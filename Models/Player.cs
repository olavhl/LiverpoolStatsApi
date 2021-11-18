using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using LiverpoolStatsApi.Interfaces;

namespace LiverpoolStatsApi.Models
{
    public class Player : IPlayer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
    }
}