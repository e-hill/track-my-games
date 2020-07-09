using System.Threading.Tasks;

namespace TrackMyGames.Services.Api
{
    public interface IPsnApiService
    {
        Task<string> GetTokenAsync();
    }
}