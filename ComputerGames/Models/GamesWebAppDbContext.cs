using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ComputerGames.Models;

public partial class GamesWebAppDbContext : DbContext
{
    public GamesWebAppDbContext()
    {
    }

    public GamesWebAppDbContext(DbContextOptions<GamesWebAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameDeveloper> GameDevelopers { get; set; }

    public virtual DbSet<GameGenre> GameGenres { get; set; }

    public virtual DbSet<GameLocalization> GameLocalizations { get; set; }

    public virtual DbSet<GamePlatform> GamePlatforms { get; set; }

    public virtual DbSet<GameType> GameTypes { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Localization> Localizations { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Screenshot> Screenshots { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usergroup> Usergroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=7X1337-PC\\SQLEXPRESS;Database=GamesWebAppDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comments");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.CommentContent)
                .HasMaxLength(2500)
                .IsUnicode(false)
                .HasColumnName("comment_content");
            entity.Property(e => e.CommentGame).HasColumnName("comment_game");
            entity.Property(e => e.CommentRating).HasColumnName("comment_rating");
            entity.Property(e => e.CommentUser).HasColumnName("comment_user");

            entity.HasOne(d => d.CommentGameNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CommentGame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comments_games");

            entity.HasOne(d => d.CommentUserNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CommentUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comments_users");
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.ToTable("developers");

            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("developer_name");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("games");

            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.GameDescription)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("game_description");
            entity.Property(e => e.GameLogo).HasColumnName("game_logo");
            entity.Property(e => e.GameName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("game_name");
            entity.Property(e => e.GamePegi).HasColumnName("game_pegi");
            entity.Property(e => e.GamePublisher).HasColumnName("game_publisher");
            entity.Property(e => e.GameRating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("game_rating");
            entity.Property(e => e.GameReleaseDate)
                .HasColumnType("date")
                .HasColumnName("game_release_date");
            entity.Property(e => e.GameTitle).HasColumnName("game_title");

            entity.HasOne(d => d.GamePublisherNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.GamePublisher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_games_publishers");

            entity.HasOne(d => d.GameTitleNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.GameTitle)
                .HasConstraintName("FK_games_titles");
        });

        modelBuilder.Entity<GameDeveloper>(entity =>
        {
            entity.ToTable("game_developers");

            entity.Property(e => e.GameDeveloperId).HasColumnName("game_developer_id");
            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");

            entity.HasOne(d => d.Developer).WithMany(p => p.GameDevelopers)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_developers_developers");

            entity.HasOne(d => d.Game).WithMany(p => p.GameDevelopers)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_developers_games");
        });

        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.HasKey(e => e.GameGenresId);

            entity.ToTable("game_genres");

            entity.Property(e => e.GameGenresId).HasColumnName("game_genres_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");

            entity.HasOne(d => d.Game).WithMany(p => p.GameGenres)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_genres_games");

            entity.HasOne(d => d.Genre).WithMany(p => p.GameGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_genres_genres");
        });

        modelBuilder.Entity<GameLocalization>(entity =>
        {
            entity.ToTable("game_localizations");

            entity.Property(e => e.GameLocalizationId).HasColumnName("game_localization_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.LocalizationId).HasColumnName("localization_id");

            entity.HasOne(d => d.Game).WithMany(p => p.GameLocalizations)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_localizations_games");

            entity.HasOne(d => d.Localization).WithMany(p => p.GameLocalizations)
                .HasForeignKey(d => d.LocalizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_localizations_localizations");
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.ToTable("game_platforms");

            entity.Property(e => e.GamePlatformId).HasColumnName("game_platform_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.PlatformId).HasColumnName("platform_id");

            entity.HasOne(d => d.Game).WithMany(p => p.GamePlatforms)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_platforms_games");

            entity.HasOne(d => d.Platform).WithMany(p => p.GamePlatforms)
                .HasForeignKey(d => d.PlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_platforms_platforms");
        });

        modelBuilder.Entity<GameType>(entity =>
        {
            entity.ToTable("game_types");

            entity.Property(e => e.GameTypeId).HasColumnName("game_type_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Game).WithMany(p => p.GameTypes)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_types_games");

            entity.HasOne(d => d.Type).WithMany(p => p.GameTypes)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_types_types");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<Localization>(entity =>
        {
            entity.ToTable("localizations");

            entity.Property(e => e.LocalizationId).HasColumnName("localization_id");
            entity.Property(e => e.Localization1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("localization");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.ToTable("platforms");

            entity.Property(e => e.PlatformId).HasColumnName("platform_id");
            entity.Property(e => e.Platform1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("platform");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.ToTable("publishers");

            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("publisher_name");
        });

        modelBuilder.Entity<Screenshot>(entity =>
        {
            entity.ToTable("screenshots");

            entity.Property(e => e.ScreenshotId).HasColumnName("screenshot_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.ScreenshotData).HasColumnName("screenshot_data");

            entity.HasOne(d => d.Game).WithMany(p => p.Screenshots)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_screenshots_games");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.ToTable("titles");

            entity.Property(e => e.TitleId).HasColumnName("title_id");
            entity.Property(e => e.TitleName)
                .HasMaxLength(60)
                .HasColumnName("title_name");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("types");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(12)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserGroup).HasColumnName("user_group");
            entity.Property(e => e.UserName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("user_password");

            entity.HasOne(d => d.UserGroupNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_usergroups");
        });

        modelBuilder.Entity<Usergroup>(entity =>
        {
            entity.ToTable("usergroups");

            entity.Property(e => e.UsergroupId).HasColumnName("usergroup_id");
            entity.Property(e => e.UsergroupName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usergroup_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
