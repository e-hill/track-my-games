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
    public class GamesRepository : IGamesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GamesRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            var gameEntity = _mapper.Map<GameEntity>(game);
            await _dbContext.Games.AddAsync(gameEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Game>(gameEntity);
        }

        public async Task<IEnumerable<Game>> GetGamesByNameAsync(string name)
        {
            var games = await _dbContext.Games.Where(x => x.Name == name).ToListAsync();
            return _mapper.Map<IEnumerable<Game>>(games);
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            var games = await _dbContext.Games.ToListAsync();
            return _mapper.Map<IEnumerable<Game>>(games);
        }

        public async Task<Game> GetGameAsync(int gameId)
        {
            var game = await _dbContext.Games.SingleOrDefaultAsync(x => x.Id == gameId);
            return _mapper.Map<Game>(game);
        }
    }
}