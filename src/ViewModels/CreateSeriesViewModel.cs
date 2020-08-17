using System.ComponentModel.DataAnnotations;

namespace TrackMyGames.ViewModels
{
    public class CreateSeriesViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}