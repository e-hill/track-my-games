using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrackMyGames.Models;
using TrackMyGames.Repositories;
using TrackMyGames.ViewModels;

namespace TrackMyGames.Controllers
{
    [Route("api/games")]
    public class GoalsController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IGoalsRepository _goalsRepository;
        private readonly IMapper _mapper;

        public GoalsController(IGamesRepository gamesRepository, IGoalsRepository goalsRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _goalsRepository = goalsRepository;
            _mapper = mapper;
        }

        [HttpGet("{gameId}/goals")]
        public async Task<IActionResult> GetGoals(int gameId)
        {
            var game = await _gamesRepository.GetGameAsync(gameId);
            if (game == null)
            {
                return BadRequest($"Game {gameId} not found");
            }

            return Ok(game.Goals ?? new Goal[0]);
        }

        [HttpPost("{gameId}/goals")]
        public async Task<IActionResult> AddGoals([FromBody] IEnumerable<CreateGoalViewModel> goalsToCreate, int gameId)
        {
            var goals = _mapper.Map<IEnumerable<Goal>>(goalsToCreate);
            var addedGoals = await _goalsRepository.ReplaceGoalsAsync(goals, gameId);
            if (!addedGoals.Any())
            {
                return NoContent();
            }

            return Ok(goals);
        }
    }
}