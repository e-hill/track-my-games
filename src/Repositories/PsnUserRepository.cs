using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public class PsnUserRepository : IPsnUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PsnUserRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PsnUser> AddAsync(PsnUser user)
        {
            var entity = _mapper.Map<PsnUserEntity>(user);
            await _dbContext.PsnUser.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PsnUser>(entity);
        }

        public async Task<PsnUser> GetUserAsync(string onlineId)
        {
            var entity = await _dbContext.PsnUser.SingleOrDefaultAsync(user => user.OnlineId == onlineId);
            return _mapper.Map<PsnUser>(entity);
        }
    }
}