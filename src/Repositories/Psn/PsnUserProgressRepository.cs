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
    public class PsnUserProgressRepository : IPsnUserProgressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PsnUserProgressRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PsnTrophyProgress> GetUserProgressAsync(int trophyId, string onlineId)
        {
            var entity = await _dbContext.PsnUserProgress.SingleOrDefaultAsync(x => x.OnlineId == onlineId && x.TrophyId == trophyId);
            return _mapper.Map<PsnTrophyProgress>(entity);
        }

        public async Task<PsnTrophyProgress> AddAsync(PsnTrophyProgress userProgress, int trophyId)
        {
            var entity = _mapper.Map<PsnUserProgressEntity>(userProgress);
            entity.Trophy = await _dbContext.PsnTrophies.SingleAsync(x => x.Id == trophyId);

            await _dbContext.PsnUserProgress.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PsnTrophyProgress>(entity);
        }

        public async Task UpdateAsync(PsnTrophyProgress userProgress)
        {
            var entity = await _dbContext.PsnUserProgress.SingleAsync(x => x.Id == userProgress.Id);

            entity.Earned = userProgress.Earned;
            entity.EarnedDate = userProgress.EarnedDate;
            entity.OnlineId = userProgress.OnlineId;

            _dbContext.PsnUserProgress.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PsnTrophyCollectionProgress>> GetUserProgressByOnlineIdAsync(string onlineId)
        {
            var userProgress = await _dbContext.PsnUserProgress
                .Where(x => x.OnlineId == onlineId && x.Trophy.CollectionId.HasValue && x.Earned)
                .GroupBy(x => x.Trophy.CollectionId.Value)
                .ToListAsync();

            return userProgress
                .Select(x => new PsnTrophyCollectionProgress
                {
                    CollectionId = x.Key,
                    TotalEarned = x.Count(),
                });
        }

        public async Task<IEnumerable<PsnTrophyProgress>> GetUserProgressByOnlineIdAndGameAsync(string onlineId, int psnGameId)
        {
            var collection = await _dbContext.PsnTrophyCollections.SingleAsync(x => x.PsnGameId == psnGameId);
            var entities = await _dbContext.PsnUserProgress.Where(x => x.OnlineId == onlineId && x.Trophy.CollectionId == collection.Id).ToListAsync();
            return _mapper.Map<IEnumerable<PsnTrophyProgress>>(entities);
        }
    }
}