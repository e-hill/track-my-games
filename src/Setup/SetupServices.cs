using Microsoft.Extensions.DependencyInjection;
using TrackMyGames.Services.Api;
using TrackMyGames.Services.Pipeline;

namespace TrackMyGames.Setup
{
    public static class SetupServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IPsnApiService, PsnApiService>();
            services.AddTransient<IPsnCommunityApiService, PsnCommunityApiService>();

            services.AddTransient<IPsnPipeline, PsnPipeline>();
        }
    }
}