using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IPsnUserProgressRepository
    {
        Task<PsnUserProgress> GetUserProgressAsync(int trophyId, int userId);

        Task<PsnUserProgress> AddAsync(int trophyId, int userId);

        Task UpdateAsync(PsnUserProgress userProgress);
    }
}