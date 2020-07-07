using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackMyGames.DbContexts;

namespace TrackMyGames.Setup
{
    public static class SetupDbContexts
    {
        public static void AddApplicationDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options => options
                .UseMySql(configuration.GetConnectionString("ApplicationDatabase")));
        }

        public static void MigrateApplicationDbContext(IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}