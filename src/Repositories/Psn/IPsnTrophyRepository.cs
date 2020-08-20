using System.Collections.Generic;
using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories.Psn
{
    public interface IPsnTrophyRepository
    {
        Task<PsnTrophy> AddAsync(PsnTrophy trophy);

        Task LinkCollectionAsync(int trophyId, int collectionId);

        Task LinkGroupAsync(int trophyId, int groupId);

        Task<PsnTrophy> GetTrophyAsync(int psnId, int collectionId);

        Task<IEnumerable<PsnTrophy>> GetTrophyByGameAsync(int psnGameId);
    }
}