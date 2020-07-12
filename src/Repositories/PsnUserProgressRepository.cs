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

        public async Task<PsnUserProgress> GetUserProgressAsync(int trophyId, int userId)
        {
            var entity = await _dbContext.PsnUserProgress.SingleOrDefaultAsync(x => x.UserId == userId && x.TrophyId == trophyId);
            return _mapper.Map<PsnUserProgress>(entity);
        }

        public async Task<PsnUserProgress> AddAsync(int trophyId, int userId)
        {
            var entity = new PsnUserProgressEntity()
            {
                Trophy = await _dbContext.PsnTrophies.SingleAsync(x => x.Id == trophyId),
                User = await _dbContext.PsnUser.SingleAsync(x => x.Id == userId),
            };

            await _dbContext.PsnUserProgress.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PsnUserProgress>(entity);
        }

        public async Task UpdateAsync(PsnUserProgress userProgress)
        {
            var entity = await _dbContext.PsnUserProgress.SingleAsync(x => x.Id == userProgress.Id);
            entity.Earned = userProgress.Earned;
            entity.EarnedDate = userProgress.EarnedDate;

            _dbContext.PsnUserProgress.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}