using System;

namespace TrackMyGames.Models
{
    public class PsnUserProgress
    {
        public int Id { get; set; }

        public bool Earned { get; set; }

        public DateTime? EarnedDate { get; set; }

        public PsnTrophy Trophy { get; set; }

        public PsnUser User { get; set; }
    }
}