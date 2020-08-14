using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class GoalEntity : BaseEntity
    {
        public string Name { get; set; }

        public int Earned { get; set; }

        public int Total { get; set; }

        public bool Completed { get; set; }

        public int? GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual GameEntity Game { get; set; }
    }
}