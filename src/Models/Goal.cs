namespace TrackMyGames.Models
{
    public class Goal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? GameId { get; set; }

        public const string PsnTrophiesName = "PSN Trophies";
    }
}