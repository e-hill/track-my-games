using System.Collections.Generic;
using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IGamesRepository
    {
        Task<Game> AddGameAsync(Game game);
        Task<IEnumerable<Game>> GetGamesByNameAsync(string name);
        Task<IEnumerable<Game>> GetGamesAsync();
    }
}