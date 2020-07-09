using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrackMyGames.Services.Api;
using TrackMyGames.Services.Pipeline;

namespace TrackMyGames.Controllers
{
    [Route("api/[controller]")]
    public class PsnController : Controller
    {
        private readonly IPsnApiService _psnApiService;
        private readonly IPsnCommunityApiService _psnCommunityApiService;
        private readonly IPsnPipeline _pipeline;
        private readonly ILogger<PsnController> _logger;

        public PsnController(IPsnApiService psnApiService, IPsnCommunityApiService psnCommunityApiService, IPsnPipeline pipeline, ILogger<PsnController> logger)
        {
            _psnApiService = psnApiService;
            _psnCommunityApiService = psnCommunityApiService;
            _pipeline = pipeline;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Update()
        {
            var accessToken = await _psnApiService.GetTokenAsync();

            if (string.IsNullOrEmpty(accessToken))
            {
                _logger.LogError("Failed to get access token from psn api endpoint.");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            var trophyResponse = await _psnCommunityApiService.GetTrophyTitlesAsync(accessToken);

            if (trophyResponse == null)
            {
                _logger.LogError("Failed to get trophy titles from psn community api endpoint.");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            await _pipeline.ProcessUpdate(trophyResponse);

            return NoContent();
        }
    }
}