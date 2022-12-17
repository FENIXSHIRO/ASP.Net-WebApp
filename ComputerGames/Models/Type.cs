using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Type
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<GameType> GameTypes { get; } = new List<GameType>();
}
