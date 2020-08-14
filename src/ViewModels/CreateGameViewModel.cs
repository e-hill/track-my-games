using System.Collections.Generic;
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

        [Required]
        public bool Archived { get; set; }

        public IEnumerable<string> Developers { get; set; }

        public IEnumerable<string> Publishers { get; set; }
    }
}