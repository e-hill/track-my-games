using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TrackMyGames.Refit;
using TrackMyGames.Settings;

namespace TrackMyGames.Controllers
{
    [Route("api/[controller]")]
    public class PsnController : Controller
    {
        private readonly IPsnApi _psnApi;
        private readonly IPsnCommunityApi _psnCommunityApi;
        private readonly PsnSettings _settings;

        public PsnController(IPsnApi psnApi, IPsnCommunityApi psnCommunityApi, IOptions<PsnSettings> options)
        {
            _psnApi = psnApi;
            _psnCommunityApi = psnCommunityApi;
            _settings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Update()
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = _settings.AuthResponseType,
                Scope = _settings.AuthScopes,
                ClientId = _settings.AuthClientId,
                RedirectUri = _settings.AuthRedirectUri,
                Prompt = "none",
            };

            var npsso = $"npsso={_settings.NpSso}";

            // get authorization token for community api
            var response = await _psnApi.Authorize(npsso, authorizeRequest);

            var accessToken = ApiResponseUtilities.GetAccessTokenFromResponse(response);

            if (string.IsNullOrEmpty(accessToken))
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Unable to generate access token.");
            }

            var getTrophiesRequest = new GetTrophyTitlesRequest
            {
                Fields = "@default,trophyTitleSmallIconUrl",
                Platform = "PS3,PS4,PSVITA",
            };

            var authHeader = "Bearer " + accessToken;

            // get trophy titles
            var trophyResponse = await _psnCommunityApi.GetTrophyTitles(authHeader, getTrophiesRequest);

            return NoContent();
        }
    }
}