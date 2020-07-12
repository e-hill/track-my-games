using Microsoft.Extensions.DependencyInjection;
using TrackMyGames.Pipelines;

namespace TrackMyGames.Setup
{
    public static class SetupPipelines
    {
        public static void AddPipelines(IServiceCollection services)
        {
            services.AddTransient<IPsnPipeline, PsnPipeline>();
        }
    }
}