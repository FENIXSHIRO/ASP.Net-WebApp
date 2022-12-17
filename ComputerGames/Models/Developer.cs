using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Developer
{
    public int DeveloperId { get; set; }

    public string DeveloperName { get; set; } = null!;

    public virtual ICollection<GameDeveloper> GameDevelopers { get; } = new List<GameDeveloper>();
}
