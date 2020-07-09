using System.Collections.Generic;

namespace TrackMyGames.Entities
{
    public class GameEntity : BaseEntity
    {
        public string Name { get; set; }

        public string ReleaseDate { get; set; }

        public string System { get; set; }

        public virtual IEnumerable<GameDeveloperEntity> GameDevelopers { get; set; }

        public virtual IEnumerable<GamePublisherEntity> GamePublishers { get; set; }

        public virtual IEnumerable<GameSeriesEntity> GameSeries { get; set; }

        public virtual IEnumerable<GoalEntity> Goals { get; set; }

        public virtual PsnTrophyCollectionEntity PsnTrophyCollection { get; set; }
    }
}