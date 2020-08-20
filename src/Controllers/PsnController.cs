using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TrackMyGames.Pipelines;
using TrackMyGames.Services;

namespace TrackMyGames.Controllers
{
    [Route("api/[controller]")]
    public class PsnController : Controller
    {
        private readonly IPsnApiService _psnApiService;
        private readonly IPsnCommunityApiService _psnCommunityApiService;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<PsnController> _logger;

        public PsnController(IPsnApiService psnApiService, IPsnCommunityApiService psnCommunityApiService, IServiceScopeFactory scopeFactory, ILogger<PsnController> logger)
        {
            _psnApiService = psnApiService;
            _psnCommunityApiService = psnCommunityApiService;
            _scopeFactory = scopeFactory;
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

            var trophyTitlesResponse = await _psnCommunityApiService.GetTrophyTitlesAsync(accessToken);

            if (trophyTitlesResponse == null || trophyTitlesResponse.TrophyTitles == null)
            {
                _logger.LogError("Failed to get trophy titles from psn community api endpoint.");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            Parallel.ForEach(trophyTitlesResponse.TrophyTitles, async (trophyTitle) =>
            {
                using var scope = _scopeFactory.CreateScope();
                var pipeline = scope.ServiceProvider.GetRequiredService<IPsnPipeline>();

                var collection = await pipeline.ProcessCollectionUpdate(trophyTitle);

                var psnId = trophyTitle.NpCommunicationId;

                if (trophyTitle.HasTrophyGroups)
                {
                    var trophyGroupsResponse = await _psnCommunityApiService.GetTrophyGroupsAsync(psnId, accessToken);

                    if (trophyGroupsResponse == null || trophyGroupsResponse.TrophyGroups == null)
                    {
                        _logger.LogError($"Failed to get trophy groups for {psnId} from psn community api endpoint.");
                    }

                    Parallel.ForEach(trophyGroupsResponse.TrophyGroups, async (trophyGroupResponse) =>
                    {
                        using var scope = _scopeFactory.CreateScope();

                        var groupId = trophyGroupResponse.TrophyGroupId;
                        var pipeline = scope.ServiceProvider.GetRequiredService<IPsnPipeline>();
                        await pipeline.ProcessTrophyGroupUpdate(trophyGroupResponse, psnId, collection.Id);

                        var trophyResponse = await _psnCommunityApiService.GetTrophiesByGroupAsync(psnId, groupId, accessToken);

                        if (trophyResponse == null || trophyResponse.Trophies == null)
                        {
                            _logger.LogError($"Failed to get trophies by group {groupId} for {psnId} from psn community api endpoint.");
                        }

                        Parallel.ForEach(trophyResponse.Trophies, async (trophyResponse) =>
                        {
                            using var scope = _scopeFactory.CreateScope();

                            var pipeline = scope.ServiceProvider.GetRequiredService<IPsnPipeline>();
                            await pipeline.ProcessTrophyUpdate(trophyResponse, psnId, collection.Id);
                        });
                    });
                }
                else
                {
                    var trophyResponse = await _psnCommunityApiService.GetTrophiesAsync(psnId, accessToken);

                    if (trophyResponse == null || trophyResponse.Trophies == null)
                    {
                        _logger.LogError($"Failed to get trophies for {psnId} from psn community api endpoint.");
                    }

                    Parallel.ForEach(trophyResponse.Trophies, async (trophyResponse) =>
                    {
                        using var scope = _scopeFactory.CreateScope();

                        var pipeline = scope.ServiceProvider.GetRequiredService<IPsnPipeline>();
                        await pipeline.ProcessTrophyUpdate(trophyResponse, psnId, collection.Id);
                    });
                }
            });

            return NoContent();
        }
    }
}