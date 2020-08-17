using Microsoft.Extensions.DependencyInjection;
using TrackMyGames.Repositories;

namespace TrackMyGames.Setup
{
    public static class SetupRepositories
    {
        public static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IGamesRepository, GamesRepository>();
            services.AddTransient<IGoalsRepository, GoalsRepository>();
            services.AddTransient<IPsnGamesRepository, PsnGamesRepository>();
            services.AddTransient<IPsnTrophyCollectionRepository, PsnTrophyCollectionRepository>();
            services.AddTransient<IPsnTrophyRepository, PsnTrophyRepository>();
            services.AddTransient<IPsnUserProgressRepository, PsnUserProgressRepository>();
            services.AddTransient<ISeriesRepository, SeriesRepository>();
        }
    }
}