using System.Threading.Tasks;
using TrackMyGames.Refit;

namespace TrackMyGames.Services.Pipeline
{
    public interface IPsnPipeline
    {
        Task ProcessTitlesUpdate(GetTrophyTitlesResponse trophyResponse);

        Task ProcessTrophiesUpdate(GetTrophiesResponse trophiesResponse, string psnId);
    }
}