using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class PsnUserProgressEntity : BaseEntity
    {
        public bool Earned { get; set; }

        public DateTime EarnedDate { get; set; }

        public int TrophyId { get; set; }

        [ForeignKey("TrophyId")]
        public virtual PsnTrophyEntity Trophy { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual PsnUserEntity User { get; set; }
    }
}