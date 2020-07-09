using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class PsnTrophyEntity : BaseEntity
    {
        public int? GroupId { get; set; }

        public virtual PsnTrophyGroupEntity Group { get; set; }

        public int CollectionId { get; set; }

        [ForeignKey("CollectionId")]
        public virtual PsnTrophyCollectionEntity Collection { get; set; }
    }
}