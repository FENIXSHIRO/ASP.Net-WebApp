using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Title
{
    public int TitleId { get; set; }

    public string TitleName { get; set; } = null!;

    public virtual ICollection<Game> Games { get; } = new List<Game>();
}
