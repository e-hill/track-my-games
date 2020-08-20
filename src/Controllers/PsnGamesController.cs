using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrackMyGames.Repositories.Psn;

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
            var onlineId = "quintaglio";
            var games = await _psnGamesRepository.GetGamesWithProgressAsync(onlineId);
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var game = await _psnGamesRepository.GetGameAsync(id);
            return Ok(game);
        }
    }
}