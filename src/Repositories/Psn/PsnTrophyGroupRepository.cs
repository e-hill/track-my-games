using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories.Psn
{
    public class PsnTrophyGroupRepository : IPsnTrophyGroupRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PsnTrophyGroupRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PsnTrophyGroup> GetTrophyGroupAsync(string psnId, int collectionId)
        {
            var trophyGroup = await _dbContext.PsnTrophyGroups.SingleOrDefaultAsync(x => x.PsnId == psnId && x.CollectionId == collectionId);
            return _mapper.Map<PsnTrophyGroup>(trophyGroup);
        }

        public async Task<PsnTrophyGroup> AddAsync(PsnTrophyGroup trophyGroup)
        {
            var entity = _mapper.Map<PsnTrophyGroupEntity>(trophyGroup);
            await _dbContext.PsnTrophyGroups.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PsnTrophyGroup>(entity);
        }

        public async Task LinkCollectionAsync(int trophyGroupId, int collectionId)
        {
            var trophyGroup = await _dbContext.PsnTrophyGroups.SingleAsync(x => x.Id == trophyGroupId);
            trophyGroup.Collection = await _dbContext.PsnTrophyCollections.SingleAsync(x => x.Id == collectionId);

            _dbContext.PsnTrophyGroups.Update(trophyGroup);
            await _dbContext.SaveChangesAsync();
        }
    }
}