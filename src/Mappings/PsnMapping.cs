using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;

public class PsnMapping : Profile
{
    public PsnMapping()
    {
        CreateMap<PsnTrophyCollection, PsnTrophyCollectionEntity>().ReverseMap();
        CreateMap<PsnTrophy, PsnTrophyEntity>().ReverseMap();
        CreateMap<PsnUser, PsnUserEntity>().ReverseMap();
        CreateMap<PsnUserProgress, PsnUserProgressEntity>().ReverseMap();
    }
}