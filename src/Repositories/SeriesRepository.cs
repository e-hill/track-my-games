using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackMyGames.DbContexts;
using TrackMyGames.Entities;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public SeriesRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Series>> GetSeriesAsync()
        {
            var series = await _dbContext.Series.ToListAsync();
            return _mapper.Map<IEnumerable<Series>>(series);
        }

        public async Task<Series> AddSeriesAsync(Series series)
        {
            var seriesEntity = _mapper.Map<SeriesEntity>(series);

            await _dbContext.Series.AddAsync(seriesEntity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Series>(seriesEntity);
        }
    }
}