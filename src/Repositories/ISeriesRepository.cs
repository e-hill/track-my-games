using System.Collections.Generic;
using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface ISeriesRepository
    {
        Task<IEnumerable<Series>> GetSeriesAsync();

        Task<Series> GetSeriesByIdAsync(int seriesId);

        Task<Series> AddSeriesAsync(Series series);
    }
}