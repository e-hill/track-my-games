using Microsoft.EntityFrameworkCore;
using TrackMyGames.Entities;

namespace TrackMyGames.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DeveloperEntity> Developers { get; set; }

        public DbSet<GameDeveloperEntity> GameDevelopers { get; set; }

        public DbSet<GameEntity> Games { get; set; }

        public DbSet<GamePublisherEntity> GamePublishers { get; set; }

        public DbSet<GameSeriesEntity> GameSeries { get; set; }

        public DbSet<GoalEntity> Goals { get; set; }

        public DbSet<PsnTrophyEntity> PsnTrophies { get; set; }

        public DbSet<PsnTrophyCollectionEntity> PsnTrophyCollections { get; set; }

        public DbSet<PsnTrophyGroupEntity> PsnTrophyGroups { get; set; }

        public DbSet<PublisherEntity> Publishers { get; set; }

        public DbSet<SeriesEntity> Series { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PsnTrophyCollectionEntity>()
                .HasIndex(i => i.PsnId)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}