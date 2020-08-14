using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;
using TrackMyGames.ViewModels;

public class GoalMapping : Profile
{
    public GoalMapping()
    {
        CreateMap<GoalEntity, Goal>().ReverseMap()
            .ForMember(x => x.Completed, y => y.MapFrom(opts => opts.Earned == opts.Total));

        CreateMap<CreateGoalViewModel, Goal>();
    }
}