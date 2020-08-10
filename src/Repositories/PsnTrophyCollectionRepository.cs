using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public class PsnTrophyCollectionRepository : IPsnTrophyCollectionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PsnTrophyCollectionRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PsnTrophyCollection> AddAsync(PsnTrophyCollection trophyCollection)
        {
            var entity = _mapper.Map<PsnTrophyCollectionEntity>(trophyCollection);
            await _dbContext.PsnTrophyCollections.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PsnTrophyCollection>(entity);
        }

        public async Task<PsnTrophyCollection> GetByPsnIdAsync(string psnId)
        {
            var entity = await _dbContext.PsnTrophyCollections.SingleOrDefaultAsync(x => x.PsnId == psnId);
            return _mapper.Map<PsnTrophyCollection>(entity);
        }

        public async Task LinkGameAsync(int collectionId, int gameId)
        {
            var collection = await _dbContext.PsnTrophyCollections.SingleAsync(x => x.Id == collectionId);
            collection.Game = await _dbContext.PsnGames.SingleAsync(x => x.Id == gameId);

            _dbContext.PsnTrophyCollections.Update(collection);
            await _dbContext.SaveChangesAsync();
        }
    }
}