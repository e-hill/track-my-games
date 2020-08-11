using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrackMyGames.Models;
using TrackMyGames.Repositories;
using TrackMyGames.ViewModels;

namespace TrackMyGames.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;

        public GamesController(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGameViewModel gameToCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = _mapper.Map<Game>(gameToCreate);
            var createdGame = await _gamesRepository.AddGameAsync(game);
            return CreatedAtAction(nameof(Get), new { id = createdGame.Id }, createdGame);
        }
    }
}