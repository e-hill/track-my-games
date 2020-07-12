using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;

public class GoalMapping : Profile
{
    public GoalMapping()
    {
        CreateMap<Goal, GoalEntity>().ReverseMap();
    }
}