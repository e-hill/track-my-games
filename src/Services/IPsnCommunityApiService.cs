using System.Threading.Tasks;
using TrackMyGames.Refit;

namespace TrackMyGames.Services
{
    public interface IPsnCommunityApiService
    {
        Task<GetTrophyTitlesResponse> GetTrophyTitlesAsync(string accessToken);

        Task<GetTrophiesResponse> GetTrophiesAsync(string psnId, string accessToken);

        Task<GetTrophiesResponse> GetTrophiesByGroupAsync(string psnId, string groupId, string accessToken);

        Task<GetTrophyGroupsResponse> GetTrophyGroupsAsync(string psnId, string accessToken);
    }
}