namespace TrackMyGames.Models
{
    public class PsnTrophyCollection
    {
        public int Id { get; set; }

        // referred to by the psn api as npCommunicationId
        public string PsnId { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public string IconUrl { get; set; }

        public string SmallIconUrl { get; set; }

        public int? GameId { get; set; }
    }
}