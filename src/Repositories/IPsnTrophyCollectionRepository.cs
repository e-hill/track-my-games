using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IPsnTrophyCollectionRepository
    {
        Task<PsnTrophyCollection> AddAsync(PsnTrophyCollection trophyCollection);

        Task<PsnTrophyCollection> GetByPsnIdAsync(string psnId);

        Task LinkGameAsync(int collectionId, int gameId);
    }
}