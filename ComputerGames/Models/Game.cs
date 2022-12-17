using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Game
{
    public int GameId { get; set; }

    public string GameName { get; set; } = null!;

    public DateTime GameReleaseDate { get; set; }

    public int GamePublisher { get; set; }

    public decimal? GameRating { get; set; }

    public int? GamePegi { get; set; }

    public byte[]? GameLogo { get; set; }

    public string GameDescription { get; set; } = null!;

    public int? GameTitle { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<GameDeveloper> GameDevelopers { get; } = new List<GameDeveloper>();

    public virtual ICollection<GameGenre> GameGenres { get; } = new List<GameGenre>();

    public virtual ICollection<GameLocalization> GameLocalizations { get; } = new List<GameLocalization>();

    public virtual ICollection<GamePlatform> GamePlatforms { get; } = new List<GamePlatform>();

    public virtual Publisher GamePublisherNavigation { get; set; } = null!;

    public virtual Title? GameTitleNavigation { get; set; }

    public virtual ICollection<GameType> GameTypes { get; } = new List<GameType>();

    public virtual ICollection<Screenshot> Screenshots { get; } = new List<Screenshot>();
}
