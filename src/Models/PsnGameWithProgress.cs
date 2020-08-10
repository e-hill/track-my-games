namespace TrackMyGames.Models
{
    public class PsnGameWithProgress
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string System { get; set; }

        public int EarnedTrophies { get; set; }

        public int TotalTrophies { get; set; }

        public PsnTrophyCollection TrophyCollection { get; set; }
    }
}