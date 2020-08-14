using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;
using TrackMyGames.ViewModels;

public class GameMapping : Profile
{
    public GameMapping()
    {
        CreateMap<Game, GameEntity>().ReverseMap()
            .ForMember(x => x.Developers, y => y.MapFrom(opts => opts.GameDevelopers.Select(z => z.Name)))
            .ForMember(x => x.Publishers, y => y.MapFrom(opts => opts.GamePublishers.Select(z => z.Name)));

        CreateMap<CreateGameViewModel, Game>();
    }
}