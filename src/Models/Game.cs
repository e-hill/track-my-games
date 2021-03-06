using System.Collections.Generic;

namespace TrackMyGames.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ReleaseDate { get; set; }

        public string System { get; set; }

        public bool Archived { get; set; }

        public bool Complete { get; set; }

        public IEnumerable<string> Developers { get; set; }

        public IEnumerable<string> Publishers { get; set; }

        public IEnumerable<Goal> Goals { get; set; }
    }
}