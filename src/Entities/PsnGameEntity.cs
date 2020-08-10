using System.Collections.Generic;

namespace TrackMyGames.Entities
{
    public class PsnGameEntity : BaseEntity
    {
        public string Name { get; set; }

        public string System { get; set; }

        public virtual PsnTrophyCollectionEntity TrophyCollection { get; set; }
    }
}