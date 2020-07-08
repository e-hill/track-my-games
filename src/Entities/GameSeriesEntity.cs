using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyGames.Entities
{
    public class GameSeriesEntity : BaseEntity
    {
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public GameEntity Game { get; set; }

        public int SeriesId { get; set; }

        [ForeignKey("SeriesId")]
        public SeriesEntity Series { get; set; }
    }
}