﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackMyGames.DbContexts;

namespace TrackMyGames.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TrackMyGames.Entities.GameDeveloperEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameDevelopers");
                });

            modelBuilder.Entity("TrackMyGames.Entities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ReleaseDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("System")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TrackMyGames.Entities.GamePublisherEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GamePublishers");
                });

            modelBuilder.Entity("TrackMyGames.Entities.GameSeriesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("SeriesId");

                    b.ToTable("GameSeries");
                });

            modelBuilder.Entity("TrackMyGames.Entities.GoalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Completed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Earned")
                        .HasColumnType("int");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("TrackMyGames.Entities.PsnGameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("System")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("PsnGames");
                });

            modelBuilder.Entity("TrackMyGames.Entities.PsnTrophyCollectionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IconUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Platform")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("PsnGameId")
                        .HasColumnType("int");

                    b.Property<string>("PsnId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("SmallIconUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PsnGameId")
                        .IsUnique();

                    b.HasIndex("PsnId")
                        .IsUnique();

                    b.ToTable("PsnTrophyCollections");
                });

            modelBuilder.Entity("TrackMyGames.Entities.PsnTrophyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("EarnedRate")
                        .HasColumnType("float");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("Hidden")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("IconUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PsnId")
                        .HasColumnType("int");

                    b.Property<int>("Rare")
                        .HasColumnType("int");

                    b.Property<string>("SmallIconUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("GroupId");

                    b.ToTable("PsnTrophies");
                });

            modelBuilder.Entity("TrackMyGames.Entities.PsnTrophyGroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IconUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PsnId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SmallIconUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("PsnTrophyGroups");
                });

            modelBuilder.Entity("TrackMyGames.Entities.PsnUserProgressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Earned")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("EarnedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OnlineId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("TrophyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrophyId", "OnlineId")
                        .IsUnique();

                    b.ToTable("PsnUserProgress");
                });

            modelBuilder.Entity("TrackMyGames.Entities.SeriesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("TrackMyGames.Entities.GameDeveloperEntity", b =>
                {
                    b.HasOne("TrackMyGames.Entities.GameEntity", "Game")
                        .WithMany("GameDevelopers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackMyGames.Entities.GamePublisherEntity", b =>
                {
                    b.HasOne("TrackMyGames.Entities.GameEntity", "Game")
                        .WithMany("GamePublishers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackMyGames.Entities.GameSeriesEntity", b =>
                {
                    b.HasOne("TrackMyGames.Entities.GameEntity", "Game")
                        .WithMany("GameSeries")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrackMyGames.Entities.SeriesEntity", "Series")
                        .WithMany("GameSeries")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackMyGames.Entities.GoalEntity", b =>
                {
                    b.HasOne("TrackMyGames.Entities.GameEntity", "Game")
                        .WithMany("Goals")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("TrackMyGames.Entities.PsnTrophyCollectionEntity", b =>
                {
                    b.HasOne("TrackMyGames.Entities.PsnGameEntity", "Game")
                        .WithOne("TrophyCollection")
                        .HasForeignKey("TrackMyGames.Entities.PsnTrophyCollectionEntity", "PsnGameId");
                });

            modelBuilder.Entity("TrackMyGames.Entities.PsnTrophyEntity", b =>
                {
                    b.HasOne("TrackMyGames.Entities.PsnTrophyCollectionEntity", "Collection")
                        .WithMany()
                        .HasForeignKey("CollectionId");

                    b.HasOne("TrackMyGames.Entities.PsnTrophyGroupEntity", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("TrackMyGames.Entities.PsnUserProgressEntity", b =>
                {
                    b.HasOne("TrackMyGames.Entities.PsnTrophyEntity", "Trophy")
                        .WithMany()
                        .HasForeignKey("TrophyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
