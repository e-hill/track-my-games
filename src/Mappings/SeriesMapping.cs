using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;
using TrackMyGames.ViewModels;

public class SeriesMapping : Profile
{
    public SeriesMapping()
    {
        CreateMap<Series, SeriesEntity>().ReverseMap();
        CreateMap<CreateSeriesViewModel, Series>();
    }
}