using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class GamePlatform
{
    public int GamePlatformId { get; set; }

    public int GameId { get; set; }

    public int PlatformId { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Platform Platform { get; set; } = null!;
}
