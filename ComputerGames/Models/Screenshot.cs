using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Screenshot
{
    public int ScreenshotId { get; set; }

    public int GameId { get; set; }

    public byte[] ScreenshotData { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;
}
