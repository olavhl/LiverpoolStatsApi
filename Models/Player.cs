using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiverpoolStatsApi.Models
{
    public class Player
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Position { get; set; }
    }
}