using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class PsnTrophyEntity : BaseEntity
    {
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public GameEntity Game { get; set; }
    }
}