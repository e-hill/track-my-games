using System.ComponentModel.DataAnnotations;

namespace TrackMyGames.ViewModels
{
    public class CreateGameViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string System { get; set; }
    }
}