namespace TrackMyGames.Models
{
    public class PsnTrophy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public string Type { get; set; }

        public string IconUrl { get; set; }

        public string SmallIconUrl { get; set; }

        public bool Hidden { get; set; }

        public int Rare { get; set; }

        public float EarnedRate { get; set; }

        public int PsnId { get; set; }

        public int? GroupId { get; set; }

        public int? CollectionId { get; set; }
    }
}