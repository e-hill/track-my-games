using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class PsnTrophyCollectionEntity : BaseEntity
    {
        // referred to by the psn api as npCommunicationId
        public string PsnId { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public string Platform { get; set; }

        public string IconUrl { get; set; }

        public string SmallIconUrl { get; set; }

        public int? GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual GameEntity Game { get; set; }
    }
}