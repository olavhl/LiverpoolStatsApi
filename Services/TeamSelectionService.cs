using MongoDB.Driver;
using LiverpoolStatsApi.Models;
using LiverpoolStatsApi.DatabasseSettings;
using System.Collections.Generic;
using System.Linq;

namespace LiverpoolStatsApi.Services
{
    public class TeamSelectionService
    {
        private readonly IMongoCollection<TeamSelection> _teamSelections;

        public TeamSelectionService(ILiverpoolStatsDatabaseSettings settings)
        {
            var client = new MongoClient( settings.ConnectionString );
            var database = client.GetDatabase( settings.DatabaseName );
            _teamSelections = database.GetCollection<TeamSelection>( settings.TeamSelectionsCollectionName );
        }

        public List<TeamSelection> GetTeamSelections()
        {
            return _teamSelections.Find( teamSelection => true ).ToList();
        }

        public TeamSelection PostTeamSelection(TeamSelection newTeamSelection)
        {
            _teamSelections.InsertOne( newTeamSelection );
            return newTeamSelection;
        }
    }
}