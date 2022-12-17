using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ComputerGames.Models;
using Microsoft.AspNetCore.Authorization;

namespace ComputerGames.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            using (var db = new GamesWebAppDbContext())
            {
                var games = (from g in db.Games
                             join p in db.Publishers
                             on g.GamePublisher equals p.PublisherId
                             join t in db.Titles
                             on g.GameTitle equals t.TitleId
                             select new
                             {
                                 GameId = g.GameId,
                                 GameName = g.GameName,
                                 GameReleaseDate = g.GameReleaseDate,
                                 GamePublisher = p.PublisherName,
                                 GameRating = g.GameRating,
                                 GamePegi = g.GamePegi,
                                 GameLogo = g.GameLogo,
                                 GameTitle = t.TitleName,
                                 GameDescription = g.GameDescription
                             }).ToList();

                ViewBag.games = games;
            }

            return View();
        }

        public IActionResult GamePage(int gameId)
        {
            using (var db = new GamesWebAppDbContext())
            {
                var game = (from g in db.Games
                             join p in db.Publishers
                             on g.GamePublisher equals p.PublisherId
                             join t in db.Titles
                             on g.GameTitle equals t.TitleId
                             where g.GameId == gameId
                             select new
                             {
                                 GameId = g.GameId,
                                 GameName = g.GameName,
                                 GameReleaseDate = g.GameReleaseDate,
                                 GamePublisher = p.PublisherName,
                                 GameRating = g.GameRating,
                                 GamePegi = g.GamePegi,
                                 GameLogo = g.GameLogo,
                                 GameTitle = t.TitleName,
                                 GameDescription = g.GameDescription
                             }).Single();

                ViewBag.game = game;

                var gameTypes = (from g in db.Games
                            join gt in db.GameTypes
                            on g.GameId equals gt.GameId
                            join t in db.Types
                            on gt.TypeId equals t.TypeId
                            where g.GameId == gameId
                            select t.TypeName
                            ).ToList();

                ViewBag.gameTypes = gameTypes;

                var gameGenres = (from g in db.Games
                                 join gg in db.GameGenres
                                 on g.GameId equals gg.GameId
                                 join gn in db.Genres
                                 on gg.GenreId equals gn.GenreId
                                 where g.GameId == gameId
                                 select gn.GenreName
                            ).ToList();

                ViewBag.gameGenres = gameGenres;

                var gameDevelopers = (from g in db.Games
                                  join gd in db.GameDevelopers
                                  on g.GameId equals gd.GameId
                                  join d in db.Developers
                                  on gd.DeveloperId equals d.DeveloperId
                                  where g.GameId == gameId
                                  select d.DeveloperName
                            ).ToList();

                ViewBag.gameDevelopers = gameDevelopers;

                var gamePlatforms = (from g in db.Games
                                      join gp in db.GamePlatforms
                                      on g.GameId equals gp.GameId
                                      join p in db.Platforms
                                      on gp.PlatformId equals p.PlatformId
                                      where g.GameId == gameId
                                      select p.Platform1
                            ).ToList();

                ViewBag.gamePlatforms = gamePlatforms;

                var gameLocals = (from g in db.Games
                                     join gl in db.GameLocalizations
                                     on g.GameId equals gl.GameId
                                     join l in db.Localizations
                                     on gl.LocalizationId equals l.LocalizationId
                                     where g.GameId == gameId
                                     select l.Localization1
                            ).ToList();

                ViewBag.gameLocals = gameLocals;

                var comments = (from c in db.Comments
                            join u in db.Users
                            on c.CommentUser equals u.UserId
                            where c.CommentGame == gameId
                                select new
                            {
                                rating = c.CommentRating,
                                content = c.CommentContent,
                                username = u.UserName,
                                userId = c.CommentUser,
                            }).ToList();

                ViewBag.comments = comments;

            }
            return View();
        }

        public string HashForMe(string pass)
        {
            var hashed = Helpers.PasswordHasher.HashPassword(pass);

            return hashed;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}