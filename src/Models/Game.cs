namespace TrackMyGames.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ReleaseDate { get; set; }

        public string System { get; set; }

        public virtual PsnTrophyCollection PsnTrophyCollection { get; set; }
    }
}