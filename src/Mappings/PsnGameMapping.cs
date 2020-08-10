using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;
using TrackMyGames.ViewModels;

public class PsnGameMapping : Profile
{
    public PsnGameMapping()
    {
        CreateMap<PsnGame, PsnGameViewModel>();
        CreateMap<PsnGame, PsnGameEntity>().ReverseMap();
    }
}