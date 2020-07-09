using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class GamePublisherEntity : BaseEntity
    {
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual GameEntity Game { get; set; }

        public int PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public virtual PublisherEntity Publisher { get; set; }
    }
}