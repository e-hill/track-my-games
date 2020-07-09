using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackMyGames.Refit;
using TrackMyGames.Settings;

namespace TrackMyGames.Services.Api
{
    public class PsnApiService : IPsnApiService
    {
        private readonly IPsnApi _psnApi;
        private readonly PsnSettings _settings;

        public PsnApiService(IPsnApi psnApi, IOptions<PsnSettings> options)
        {
            _psnApi = psnApi;
            _settings = options.Value;
        }

        public async Task<string> GetTokenAsync()
        {
            var npsso = $"npsso={_settings.NpSso}";
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = _settings.AuthResponseType,
                Scope = _settings.AuthScopes,
                ClientId = _settings.AuthClientId,
                RedirectUri = _settings.AuthRedirectUri,
                Prompt = "none",
            };

            var response = await _psnApi.Authorize(npsso, authorizeRequest);

            return ApiResponseUtilities.GetAccessTokenFromResponse(response);
        }
    }
}