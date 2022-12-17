using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<GameGenre> GameGenres { get; } = new List<GameGenre>();
}
