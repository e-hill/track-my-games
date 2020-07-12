using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
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

        public async Task<PsnUserProgress> GetUserProgressAsync(int trophyId, string onlineId)
        {
            var entity = await _dbContext.PsnUserProgress.SingleOrDefaultAsync(x => x.OnlineId == onlineId && x.TrophyId == trophyId);
            return _mapper.Map<PsnUserProgress>(entity);
        }

        public async Task<PsnUserProgress> AddAsync(PsnUserProgress userProgress, int trophyId)
        {
            var entity = _mapper.Map<PsnUserProgressEntity>(userProgress);
            entity.Trophy = await _dbContext.PsnTrophies.SingleAsync(x => x.Id == trophyId);

            await _dbContext.PsnUserProgress.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PsnUserProgress>(entity);
        }

        public async Task UpdateAsync(PsnUserProgress userProgress)
        {
            var entity = await _dbContext.PsnUserProgress.SingleAsync(x => x.Id == userProgress.Id);

            entity.Earned = userProgress.Earned;
            entity.EarnedDate = userProgress.EarnedDate;
            entity.OnlineId = userProgress.OnlineId;

            _dbContext.PsnUserProgress.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}