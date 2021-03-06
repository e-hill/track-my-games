using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories.Psn
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

        public async Task LinkGroupAsync(int trophyId, int groupId)
        {
            var trophy = await _dbContext.PsnTrophies.SingleAsync(x => x.Id == trophyId);
            trophy.Group = await _dbContext.PsnTrophyGroups.SingleAsync(x => x.Id == groupId);

            _dbContext.PsnTrophies.Update(trophy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PsnTrophy> GetTrophyAsync(int psnId, int collectionId)
        {
            var trophy = await _dbContext.PsnTrophies.SingleOrDefaultAsync(x => x.PsnId == psnId && x.CollectionId == collectionId);
            return _mapper.Map<PsnTrophy>(trophy);
        }

        public async Task<IEnumerable<PsnTrophy>> GetTrophyByGameAsync(int psnGameId)
        {
            var game = await _dbContext.PsnGames.SingleAsync(x => x.Id == psnGameId);
            var trophies = await _dbContext.PsnTrophies.Where(x => x.CollectionId == game.TrophyCollection.Id).ToListAsync();
            return _mapper.Map<IEnumerable<PsnTrophy>>(trophies);
        }
    }
}