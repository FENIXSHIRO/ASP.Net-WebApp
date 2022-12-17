using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Localization
{
    public int LocalizationId { get; set; }

    public string? Localization1 { get; set; }

    public virtual ICollection<GameLocalization> GameLocalizations { get; } = new List<GameLocalization>();
}
