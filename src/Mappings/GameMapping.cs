using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;

public class GameMapping : Profile
{
    public GameMapping()
    {
        CreateMap<Game, GameEntity>().ReverseMap();
    }
}