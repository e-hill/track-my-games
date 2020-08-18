

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrackMyGames.Models;
using TrackMyGames.Repositories;
using TrackMyGames.ViewModels;

namespace TrackMyGames.Controllers
{
    [Route("api/[controller]")]
    public class SeriesController : Controller
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;

        public SeriesController(ISeriesRepository seriesRepository, IMapper mapper)
        {
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var series = await _seriesRepository.GetSeriesAsync();
            return Ok(series);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSeriesViewModel seriesToCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var series = _mapper.Map<Series>(seriesToCreate);
            var createdSeries = await _seriesRepository.AddSeriesAsync(series);
            return CreatedAtAction(nameof(Get), new { id = createdSeries.Id }, createdSeries);
        }

        // [HttpGet("{seriesId}/games")]
        // public async Task<IActionResult> GetGames(int seriesId)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     return Ok(games);
        // }

        // [HttpPost("{seriesId}/games")]
        // public async Task<IActionResult> PostGames([FromBody] IEnumerable<CreateGameViewModel> gamesToAdd, int seriesId)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     return CreatedAtAction(nameof(GetGames));
        // }
    }
}
