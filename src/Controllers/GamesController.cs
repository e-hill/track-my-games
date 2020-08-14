using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
            if (game == null)
            {
                return NotFound();
            }

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

        [HttpPatch("{gameId}")]
        public async Task<IActionResult> Patch([FromBody] JsonPatchDocument<CreateGameViewModel> patchDocument, int gameId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameToUpdate = new CreateGameViewModel();
            patchDocument.ApplyTo(gameToUpdate);

            var game = _mapper.Map<Game>(gameToUpdate);
            game.Id = gameId;

            var updatedGame = await _gamesRepository.UpdateGameAsync(game);
            return Ok(updatedGame);
        }
    }
}