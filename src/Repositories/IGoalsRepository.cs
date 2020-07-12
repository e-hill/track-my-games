using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IGoalsRepository
    {
        Task<Goal> AddAsync(Goal goal);

        Task LinkGameAsync(int goalId, int gameId);
    }
}