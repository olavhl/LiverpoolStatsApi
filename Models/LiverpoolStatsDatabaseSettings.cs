namespace LiverpoolStatsApi.Models
{

    public class LiverpoolStatsDatabaseSettings : ILiverpoolStatsDatabaseSettings
    {
        public string PlayersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILiverpoolStatsDatabaseSettings
    {
        string PlayersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}