using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class GameDeveloperEntity : BaseEntity
    {
        public string Name { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual GameEntity Game { get; set; }
    }
}