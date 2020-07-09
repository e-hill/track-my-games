using AutoMapper;
using TrackMyGames.Entities;
using TrackMyGames.Models;

public class PsnMapping : Profile
{
    public PsnMapping()
    {
        CreateMap<PsnTrophyCollection, PsnTrophyCollectionEntity>().ReverseMap();
    }
}