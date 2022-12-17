using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class GameType
{
    public int GameTypeId { get; set; }

    public int GameId { get; set; }

    public int TypeId { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
