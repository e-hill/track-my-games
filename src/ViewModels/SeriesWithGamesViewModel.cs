using System.Collections.Generic;
using TrackMyGames.Models;

namespace TrackMyGames.ViewModels
{
    public class SeriesWithGamesViewModel : Series
    {
        public IEnumerable<Game> Games { get; set; }
    }
}