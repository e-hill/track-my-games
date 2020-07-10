using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackMyGames.Repositories;

namespace TrackMyGames.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gamesRepository.GetGamesAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var game = await _gamesRepository.GetGameAsync(id);
            return Ok(game);
        }
    }
}