using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;

public class PsnGameMapping : Profile
{
    public PsnGameMapping()
    {
        CreateMap<PsnGame, PsnGameEntity>().ReverseMap();
    }
}