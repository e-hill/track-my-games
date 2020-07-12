using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IPsnUserProgressRepository
    {
        Task<PsnUserProgress> GetUserProgressAsync(int trophyId, string onlineId);

        Task<PsnUserProgress> AddAsync(PsnUserProgress userProgress, int trophyId);

        Task UpdateAsync(PsnUserProgress userProgress);
    }
}