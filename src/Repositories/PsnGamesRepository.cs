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
    }
}