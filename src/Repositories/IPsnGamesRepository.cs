using System.Collections.Generic;
using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IPsnGamesRepository
    {
        Task<PsnGame> AddGameAsync(PsnGame game);

        Task<IEnumerable<PsnGame>> GetGamesByNameAsync(string name);

        Task<IEnumerable<PsnGame>> GetGamesAsync();

        Task<PsnGame> GetGameAsync(int gameId);

        Task<IEnumerable<PsnGameWithProgress>> GetGamesWithProgressAsync(string onlineId);
    }
}