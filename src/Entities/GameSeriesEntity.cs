using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class GameSeriesEntity : BaseEntity
    {
        public string Name { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual GameEntity Game { get; set; }

        public int SeriesId { get; set; }

        [ForeignKey("SeriesId")]
        public virtual SeriesEntity Series { get; set; }
    }
}