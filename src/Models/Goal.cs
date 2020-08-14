namespace TrackMyGames.Models
{
    public class Goal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Earned { get; set; }

        public int Total { get; set; }

        public bool Completed { get; set; }

        public int? GameId { get; set; }
    }
}