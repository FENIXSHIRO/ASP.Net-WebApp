using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class GameLocalization
{
    public int GameLocalizationId { get; set; }

    public int GameId { get; set; }

    public int LocalizationId { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Localization Localization { get; set; } = null!;
}
