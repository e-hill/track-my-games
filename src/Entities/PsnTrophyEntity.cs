using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class PsnTrophyEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Detail { get; set; }

        public string Type { get; set; }

        public string IconUrl { get; set; }

        public string SmallIconUrl { get; set; }

        public bool Hidden { get; set; }

        public int Rare { get; set; }

        public float EarnedRate { get; set; }

        public int PsnId { get; set; }

        public int? GroupId { get; set; }

        public virtual PsnTrophyGroupEntity Group { get; set; }

        public int? CollectionId { get; set; }

        [ForeignKey("CollectionId")]
        public virtual PsnTrophyCollectionEntity Collection { get; set; }
    }
}