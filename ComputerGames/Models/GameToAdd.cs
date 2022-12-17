using System;
using System.Collections.Generic;

namespace ComputerGames.Models
{
    public class GameToAdd
    {
        public string GameName { get; set; } = null!;

        public DateTime GameReleaseDate { get; set; }

        public int GamePublisher { get; set; }

        public int? GamePegi { get; set; }

        public IFormFile LogoImage { get; set; }

        public string GameDescription { get; set; } = null!;

        public int? GameTitle { get; set; }
    }
}
