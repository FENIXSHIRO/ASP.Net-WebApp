using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public virtual ICollection<Game> Games { get; } = new List<Game>();
}
