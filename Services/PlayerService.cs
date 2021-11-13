using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using LiverpoolStatsApi.Models;

namespace LiverpoolStatsApi.Services
{
    public class PlayerService
    {
        private readonly IMongoCollection<Player> _players;

        public PlayerService(ILiverpoolStatsDatabaseSettings settings)
        {
            var client = new MongoClient( settings.ConnectionString );
                var database = client.GetDatabase( settings.DatabaseName );
                _players = database.GetCollection<Player>( settings.PlayersCollectionName );
        }

        public List<Player> GetPlayers()
        {
            return _players.Find( player => true ).ToList();
        }

        public Player GetPlayer(string id)
        {
            return _players.Find<Player>(player => player.Id == id).FirstOrDefault();
        }

        public Player PostPlayer(Player newPlayer)
        {
            _players.InsertOne( newPlayer );
            return newPlayer;
        }

        public void UpdatePlayer(Player updatedPlayer)
        {
            _players.ReplaceOne( player => player.Id == updatedPlayer.Id, updatedPlayer);
        }

        public void RemovePlayer(string id)
        {
            _players.DeleteOne( player => player.Id == id );
        }
            
    }

}