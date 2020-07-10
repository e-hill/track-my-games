using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public class PsnTrophyRepository : IPsnTrophyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PsnTrophyRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PsnTrophy> AddAsync(PsnTrophy trophy)
        {
            var entity = _mapper.Map<PsnTrophyEntity>(trophy);
            await _dbContext.PsnTrophies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PsnTrophy>(entity);
        }

        public async Task LinkCollectionAsync(int trophyId, int collectionId)
        {
            var trophy = await _dbContext.PsnTrophies.SingleAsync(x => x.Id == trophyId);
            trophy.Collection = await _dbContext.PsnTrophyCollections.SingleAsync(x => x.Id == collectionId);

            _dbContext.PsnTrophies.Update(trophy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PsnTrophy> GetTrophyAsync(int psnId, int collectionId)
        {
            var trophy = await _dbContext.PsnTrophies.SingleOrDefaultAsync(x => x.PsnId == psnId && x.CollectionId == collectionId);
            return _mapper.Map<PsnTrophy>(trophy);
        }
    }
}