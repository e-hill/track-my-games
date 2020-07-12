using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackMyGames.Refit;
using TrackMyGames.Settings;

namespace TrackMyGames.Services
{
    public class PsnCommunityApiService : IPsnCommunityApiService
    {
        private readonly IPsnCommunityApi _psnCommunityApi;
        private readonly PsnSettings _settings;

        public PsnCommunityApiService(IPsnCommunityApi psnCommunityApi, IOptions<PsnSettings> options)
        {
            _psnCommunityApi = psnCommunityApi;
            _settings = options.Value;
        }

        public async Task<GetTrophyTitlesResponse> GetTrophyTitlesAsync(string accessToken)
        {
            var request = new GetTrophyTitlesRequest
            {
                Fields = "@default,trophyTitleSmallIconUrl",
                Platform = "PS3,PS4,PSVITA",
            };

            var authHeader = "Bearer " + accessToken;

            return await _psnCommunityApi.GetTrophyTitles(authHeader, request);
        }

        public async Task<GetTrophiesResponse> GetTrophiesAsync(string psnId, string accessToken)
        {
            var request = new GetTrophiesRequest
            {
                Fields = "@default,trophyRare,trophyEarnedRate,trophySmallIconUrl",
                VisibleType = 1
            };

            var authHeader = "Bearer " + accessToken;

            return await _psnCommunityApi.GetTrophies(authHeader, psnId, request);
        }
    }
}