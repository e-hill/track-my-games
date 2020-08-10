using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class PsnTrophyGroupEntity : BaseEntity
    {
        public string PsnId { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public string IconUrl { get; set; }

        public string SmallIconUrl { get; set; }
    }
}