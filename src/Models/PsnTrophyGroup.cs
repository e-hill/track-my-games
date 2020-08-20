namespace TrackMyGames.Models
{
    public class PsnTrophyGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public string IconUrl { get; set; }

        public string SmallIconUrl { get; set; }

        public string PsnId { get; set; }

        public int? CollectionId { get; set; }
    }
}