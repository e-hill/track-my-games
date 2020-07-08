using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackMyGames.Entities
{
    public class GameEntity : BaseEntity
    {
        public string Name { get; set; }

        public string ReleaseDate { get; set; }

        public string System { get; set; }

        public string IconUrl { get; set; }

        public string SmallIconUrl { get; set; }

        public IEnumerable<GameDeveloperEntity> GameDevelopers { get; set; }

        public IEnumerable<GamePublisherEntity> GamePublishers { get; set; }

        public IEnumerable<GameSeriesEntity> GameSeries { get; set; }

        public IEnumerable<GoalEntity> Goals { get; set; }

        public IEnumerable<PsnTrophyEntity> PsnTrophies { get; set; }
    }
}