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

        public async Task<IActionResult> Get()
        {
            var games = await _gamesRepository.GetGamesAsync();
            return Ok(games);
        }
    }
}