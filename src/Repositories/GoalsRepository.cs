using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public class GoalsRepository : IGoalsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GoalsRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Goal> AddAsync(Goal goal)
        {
            var entity = _mapper.Map<GoalEntity>(goal);
            await _dbContext.Goals.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Goal>(entity);
        }

        public async Task LinkGameAsync(int goalId, int gameId)
        {
            var goal = await _dbContext.Goals.SingleAsync(x => x.Id == goalId);
            goal.Game = await _dbContext.Games.SingleAsync(x => x.Id == gameId);

            _dbContext.Goals.Update(goal);
            await _dbContext.SaveChangesAsync();
        }
    }
}