using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IPsnUserProgressRepository
    {
        Task<PsnTrophyProgress> GetUserProgressAsync(int trophyId, string onlineId);

        Task<PsnTrophyProgress> AddAsync(PsnTrophyProgress userProgress, int trophyId);

        Task UpdateAsync(PsnTrophyProgress userProgress);

        Task<IEnumerable<PsnTrophyCollectionProgress>> GetUserProgressByOnlineIdAsync(string onlineId);

        Task<IEnumerable<PsnTrophyProgress>> GetUserProgressByOnlineIdAndGameAsync(string onlineId, int psnGameId);
    }
}