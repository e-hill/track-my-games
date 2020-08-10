using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public class PsnGamesRepository : IPsnGamesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PsnGamesRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PsnGame> AddGameAsync(PsnGame game)
        {
            var gameEntity = _mapper.Map<PsnGameEntity>(game);
            await _dbContext.PsnGames.AddAsync(gameEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PsnGame>(gameEntity);
        }

        public async Task<IEnumerable<PsnGame>> GetGamesByNameAsync(string name)
        {
            var games = await _dbContext.PsnGames.Where(x => x.Name == name).ToListAsync();
            return _mapper.Map<IEnumerable<PsnGame>>(games);
        }

        public async Task<IEnumerable<PsnGame>> GetGamesAsync()
        {
            var games = await _dbContext.PsnGames.ToListAsync();
            return _mapper.Map<IEnumerable<PsnGame>>(games);
        }

        public async Task<PsnGame> GetGameAsync(int gameId)
        {
            var game = await _dbContext.PsnGames.SingleOrDefaultAsync(x => x.Id == gameId);
            return _mapper.Map<PsnGame>(game);
        }

        public async Task<IEnumerable<PsnGameWithProgress>> GetGamesWithProgressAsync(string onlineId)
        {
            var games = await GetGamesAsync();
            var userProgress = await _dbContext.PsnUserProgress
                .Include(x => x.Trophy)
                .Where(x => x.OnlineId == onlineId).ToListAsync();

            return from game in games
                   let progress = userProgress.Where(x => x.Trophy.CollectionId == game.TrophyCollection.Id)
                   select new PsnGameWithProgress
                   {
                       Id = game.Id,
                       Name = game.Name,
                       System = game.System,
                       TrophyCollection = game.TrophyCollection,
                       EarnedTrophies = progress.Count(x => x.Earned),
                       TotalTrophies = progress.Count()
                   };
        }
    }
}