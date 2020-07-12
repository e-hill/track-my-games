using System.Threading.Tasks;
using TrackMyGames.Models;

namespace TrackMyGames.Repositories
{
    public interface IPsnUserRepository
    {
        Task<PsnUser> AddAsync(PsnUser user);

        Task<PsnUser> GetUserAsync(string onlineId);
    }
}