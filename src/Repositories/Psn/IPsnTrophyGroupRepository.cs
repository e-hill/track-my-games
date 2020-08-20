using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories.Psn
{
    public interface IPsnTrophyGroupRepository
    {
        Task<PsnTrophyGroup> GetTrophyGroupAsync(string psnId, int collectionId);

        Task<PsnTrophyGroup> AddAsync(PsnTrophyGroup trophyGroup);

        Task LinkCollectionAsync(int trophyGroupId, int collectionId);
    }
}