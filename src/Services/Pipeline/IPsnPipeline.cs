using System.Threading.Tasks;
using TrackMyGames.Refit;

namespace TrackMyGames.Services.Pipeline
{
    public interface IPsnPipeline
    {
        Task ProcessUpdate(GetTrophyTitlesResponse trophyResponse);
    }
}