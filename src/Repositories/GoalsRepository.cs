using System;
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
    public class GoalsRepository : IGoalsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GoalsRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Goal>> ReplaceGoalsAsync(IEnumerable<Goal> goals, int gameId)
        {
            var newGoals = _mapper.Map<IEnumerable<GoalEntity>>(goals);
            newGoals = await LinkGoalsAsync(newGoals, gameId);
            var oldGoals = _dbContext.Goals.Where(x => x.GameId == gameId);

            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                _dbContext.Goals.RemoveRange(oldGoals);
                await _dbContext.Goals.AddRangeAsync(newGoals);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return _mapper.Map<IEnumerable<Goal>>(newGoals);
        }

        private async Task<IEnumerable<GoalEntity>> LinkGoalsAsync(IEnumerable<GoalEntity> goals, int gameId)
        {
            var game = await _dbContext.Games.SingleOrDefaultAsync(x => x.Id == gameId);
            return goals.Select(x => { x.Game = game; return x; });
        }
    }
}