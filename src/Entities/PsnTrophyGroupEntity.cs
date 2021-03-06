using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class PsnTrophyGroupEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Detail { get; set; }

        public string IconUrl { get; set; }

        public string SmallIconUrl { get; set; }

        public string PsnId { get; set; }

        public int? CollectionId { get; set; }

        [ForeignKey("CollectionId")]
        public virtual PsnTrophyCollectionEntity Collection { get; set; }
    }
}