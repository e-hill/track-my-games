using System.Collections.Generic;

namespace TrackMyGames.Entities
{
    public class PublisherEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<GamePublisherEntity> GamePublishers { get; set; }
    }
}