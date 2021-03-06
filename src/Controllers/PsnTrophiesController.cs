using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackMyGames.Repositories.Psn;

namespace TrackMyGames.Controllers
{
    [Route("api/psn/trophies")]
    public class PsnTrophiesController : Controller
    {
        private readonly IPsnTrophyRepository _psnTrophyRepository;

        public PsnTrophiesController(IPsnTrophyRepository psnTrophyRepository)
        {
            _psnTrophyRepository = psnTrophyRepository;
        }

        [HttpGet("findByGame")]
        public async Task<IActionResult> FindByGame([FromQuery] int gameId)
        {
            var game = await _psnTrophyRepository.GetTrophyByGameAsync(gameId);
            return Ok(game);
        }
    }
}