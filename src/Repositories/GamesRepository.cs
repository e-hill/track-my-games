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

            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                await _dbContext.Games.AddAsync(gameEntity);

                if (game.Developers != null && game.Developers.Any())
                {
                    var developer = new GameDeveloperEntity
                    {
                        Game = gameEntity,
                        Name = game.Developers.First()
                    };

                    await _dbContext.GameDevelopers.AddAsync(developer);
                }

                if (game.Publishers != null && game.Publishers.Any())
                {
                    var publisher = new GamePublisherEntity
                    {
                        Game = gameEntity,
                        Name = game.Publishers.First()
                    };

                    await _dbContext.GamePublishers.AddAsync(publisher);
                }

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return _mapper.Map<Game>(gameEntity);
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            var updatedGameEntity = _mapper.Map<GameEntity>(game);
            var gameEntity = await _dbContext.Games.SingleAsync(x => x.Id == game.Id);

            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                gameEntity.Name = updatedGameEntity.Name;
                gameEntity.ReleaseDate = updatedGameEntity.ReleaseDate;
                gameEntity.System = updatedGameEntity.System;
                _dbContext.Games.Update(gameEntity);

                var developerEntity = await _dbContext.GameDevelopers.FirstOrDefaultAsync(x => x.GameId == game.Id);
                if (developerEntity != null)
                {
                    if (game.Developers != null && game.Developers.Any())
                    {
                        developerEntity.Name = game.Developers.First();
                        _dbContext.GameDevelopers.Update(developerEntity);
                    }
                    else
                    {
                        _dbContext.GameDevelopers.Remove(developerEntity);
                    }
                }
                else
                {
                    if (game.Developers != null && game.Developers.Any())
                    {
                        var developer = new GameDeveloperEntity
                        {
                            Game = gameEntity,
                            Name = game.Developers.First()
                        };

                        await _dbContext.GameDevelopers.AddAsync(developer);
                    }
                }

                var publisherEntity = await _dbContext.GamePublishers.FirstOrDefaultAsync(x => x.GameId == game.Id);
                if (publisherEntity != null)
                {
                    if (game.Publishers != null && game.Publishers.Any())
                    {
                        publisherEntity.Name = game.Publishers.First();
                        _dbContext.GamePublishers.Update(publisherEntity);
                    }
                    else
                    {
                        _dbContext.GamePublishers.Remove(publisherEntity);
                    }
                }
                else
                {
                    if (game.Publishers != null && game.Publishers.Any())
                    {
                        var publisher = new GamePublisherEntity
                        {
                            Game = gameEntity,
                            Name = game.Publishers.First()
                        };

                        await _dbContext.GamePublishers.AddAsync(publisher);
                    }
                }

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return _mapper.Map<Game>(updatedGameEntity);
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