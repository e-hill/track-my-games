using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackMyGames.Settings;

namespace TrackMyGames.Setup
{
    public static class SetupConfigurations
    {
        public static void AddSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PsnSettings>(configuration.GetSection("Psn"));
        }
    }
}