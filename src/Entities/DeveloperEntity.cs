using System.Collections.Generic;

namespace TrackMyGames.Entities
{
    public class DeveloperEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<GameDeveloperEntity> GameDevelopers { get; set; }
    }
}