using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IPsnTrophyRepository
    {
        Task<PsnTrophy> AddAsync(PsnTrophy trophy);

        Task LinkCollectionAsync(int trophyId, int collectionId);

        Task<PsnTrophy> GetTrophyAsync(int psnId, int collectionId);
    }
}