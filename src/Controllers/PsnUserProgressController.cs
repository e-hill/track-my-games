using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackMyGames.Repositories;

namespace TrackMyGames.Controllers
{
    [Route("api/psn/user-progress")]
    public class PsnUserProgressController : Controller
    {
        private readonly IPsnUserProgressRepository _userProgressRepository;

        public PsnUserProgressController(IPsnUserProgressRepository userProgressRepository)
        {
            _userProgressRepository = userProgressRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var onlineId = "quintaglio";
            var userProgress = await _userProgressRepository.GetUserProgressByOnlineIdAsync(onlineId);
            return Ok(userProgress);
        }

        [HttpGet("findByGame")]
        public async Task<IActionResult> FindByGame([FromQuery] int gameId)
        {
            var onlineId = "quintaglio";
            var userProgress = await _userProgressRepository.GetUserProgressByOnlineIdAndGameAsync(onlineId, gameId);
            return Ok(userProgress);
        }
    }
}