namespace LiverpoolStatsApi.DatabasseSettings
{

    public class LiverpoolStatsDatabaseSettings : ILiverpoolStatsDatabaseSettings
    {
        public string PlayersCollectionName { get; set; }
        public string TeamSelectionsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILiverpoolStatsDatabaseSettings
    {
        string PlayersCollectionName { get; set; }
        string TeamSelectionsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}