namespace LiverpoolStatsApi.Interfaces
{
    public interface IPlayer
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Age { get; set; }
        string Country { get; set; }
        string Position { get; set; }
        string Image { get; set; }
    }
}