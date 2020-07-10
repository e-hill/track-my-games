using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackMyGames.Repositories;
using TrackMyGames.Settings;

namespace TrackMyGames.Setup
{
    public static class SetupRepositories
    {
        public static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IGamesRepository, GamesRepository>();
            services.AddTransient<IPsnTrophyCollectionRepository, PsnTrophyCollectionRepository>();
            services.AddTransient<IPsnTrophyRepository, PsnTrophyRepository>();
        }
    }
}