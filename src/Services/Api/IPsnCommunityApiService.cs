using System.Threading.Tasks;
using TrackMyGames.Refit;

namespace TrackMyGames.Services.Api
{
    public interface IPsnCommunityApiService
    {
        Task<GetTrophyTitlesResponse> GetTrophyTitlesAsync(string accessToken);

        Task<GetTrophiesResponse> GetTrophiesAsync(string psnId, string accessToken);
    }
}