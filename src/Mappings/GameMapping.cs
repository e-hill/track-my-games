using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;
using TrackMyGames.ViewModels;

public class GameMapping : Profile
{
    public GameMapping()
    {
        CreateMap<Game, GameEntity>().ReverseMap();
        CreateMap<CreateGameViewModel, Game>();
    }
}