using System.Threading.Tasks;
using TrackMyGames.Models;
using TrackMyGames.Refit;

namespace TrackMyGames.Pipelines
{
    public interface IPsnPipeline
    {
        Task<PsnTrophyCollection> ProcessCollectionUpdate(GetTrophyTitlesResponse.TrophyTitlesResponse trophyTitle);

        Task ProcessTrophyUpdate(GetTrophiesResponse.TrophiesResponse trophyResponse, string psnId, int collectionId);
    }
}