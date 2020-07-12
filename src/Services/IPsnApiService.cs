using System.Threading.Tasks;

namespace TrackMyGames.Services
{
    public interface IPsnApiService
    {
        Task<string> GetTokenAsync();
    }
}