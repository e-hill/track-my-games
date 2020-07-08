using System.Collections.Generic;

namespace TrackMyGames.Entities
{
    public class SeriesEntity : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<GameSeriesEntity> GameSeries { get; set; }
    }
}