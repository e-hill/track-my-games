using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrackMyGames.Repositories;
using TrackMyGames.ViewModels;

namespace TrackMyGames.Controllers
{
    [Route("api/psn/games")]
    public class PsnGamesController : Controller
    {
        private readonly IPsnGamesRepository _psnGamesRepository;
        private readonly IPsnUserProgressRepository _userProgressRepository;
        private readonly IMapper _mapper;

        public PsnGamesController(IPsnGamesRepository psnGamesRepository, IPsnUserProgressRepository userProgressRepository, IMapper mapper)
        {
            _psnGamesRepository = psnGamesRepository;
            _userProgressRepository = userProgressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _psnGamesRepository.GetGamesAsync();
            var gameViewModels = new List<PsnGameViewModel>();

            foreach (var game in games)
            {
                var gameViewModel = _mapper.Map<PsnGameViewModel>(game);

                var onlineId = "quintaglio";
                var userProgress = await _userProgressRepository.GetUserProgressByOnlineIdAndGameAsync(onlineId, game.Id);
                gameViewModel.EarnedTrophies = userProgress.Count(x => x.Earned);
                gameViewModel.TotalTrophies = userProgress.Count();

                gameViewModels.Add(gameViewModel);
            }

            return Ok(gameViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var game = await _psnGamesRepository.GetGameAsync(id);
            return Ok(game);
        }
    }
}