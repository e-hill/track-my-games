using System.Threading.Tasks;
using TrackMyGames.Models;
using TrackMyGames.Refit;

namespace TrackMyGames.Pipelines
{
    public interface IPsnPipeline
    {
        Task<PsnTrophyCollection> ProcessCollectionUpdate(GetTrophyTitlesResponse.TrophyTitlesDetails trophyTitle);

        Task ProcessTrophyUpdate(GetTrophiesResponse.TrophiesResponse trophyResponse, string psnId, int collectionId);

        Task ProcessTrophyWithGroupUpdate(GetTrophiesResponse.TrophiesResponse trophyResponse, string psnId, int collectionId, int groupId);

        Task<PsnTrophyGroup> ProcessTrophyGroupUpdate(GetTrophyGroupsResponse.TrophyGroupsDetails trophyGroupResponse, string psnId, int collectionId);
    }
}