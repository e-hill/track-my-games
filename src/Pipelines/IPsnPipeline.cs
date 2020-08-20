using System.Threading.Tasks;
using TrackMyGames.Models;
using TrackMyGames.Refit;

namespace TrackMyGames.Pipelines
{
    public interface IPsnPipeline
    {
        Task<PsnTrophyCollection> ProcessCollectionUpdate(GetTrophyTitlesResponse.TrophyTitlesDetails trophyTitle);

        Task ProcessTrophyUpdate(GetTrophiesResponse.TrophiesResponse trophyResponse, string psnId, int collectionId);

        Task ProcessTrophyGroupUpdate(GetTrophyGroupsResponse.TrophyGroupsDetails trophyGroupResponse, string psnId, int collectionId);
    }
}