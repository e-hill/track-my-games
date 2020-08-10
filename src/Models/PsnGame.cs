namespace TrackMyGames.Models
{
    public class PsnGame
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string System { get; set; }

        public PsnTrophyCollection TrophyCollection { get; set; }
    }
}