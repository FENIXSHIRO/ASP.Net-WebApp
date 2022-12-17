using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Platform
{
    public int PlatformId { get; set; }

    public string Platform1 { get; set; } = null!;

    public virtual ICollection<GamePlatform> GamePlatforms { get; } = new List<GamePlatform>();
}
