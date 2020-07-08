using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class GameDeveloperEntity : BaseEntity
    {
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public GameEntity Game { get; set; }

        public int DeveloperId { get; set; }

        [ForeignKey("DeveloperId")]
        public DeveloperEntity Developer { get; set; }
    }
}