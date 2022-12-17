using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class GameGenre
{
    public int GameGenresId { get; set; }

    public int GameId { get; set; }

    public int GenreId { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;
}
