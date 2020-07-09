using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class PsnTrophyEntity : BaseEntity
    {
        public int? GroupId { get; set; }

        public PsnTrophyGroupEntity Group { get; set; }

        public int CollectionId { get; set; }

        [ForeignKey("CollectionId")]
        public PsnTrophyCollectionEntity Collection { get; set; }
    }
}