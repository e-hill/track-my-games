using System.Collections.Generic;
using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IGoalsRepository
    {
        Task<IEnumerable<Goal>> ReplaceGoalsAsync(IEnumerable<Goal> goals, int gameId);
    }
}