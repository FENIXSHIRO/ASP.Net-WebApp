using Microsoft.AspNetCore.Mvc;
using ComputerGames.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace ComputerGames.Controllers
{
    public class EditController : Controller
    {
        [Authorize]
        public ActionResult AddGame()
        {
            List<Developer> developers = new List<Developer>();
            List<Publisher> publishers = new List<Publisher>();
            List<Genre> genres = new List<Genre>();
            List<Models.Type> types = new List<Models.Type>();
            List<Localization> localizations = new List<Localization>();
            List<Platform> platforms = new List<Platform>();
            List<Title> titles = new List<Title>();

            using (var db = new GamesWebAppDbContext())
            {
                ViewBag.developers = db.Developers.ToList();
                ViewBag.publishers = db.Publishers.ToList();
                ViewBag.genres = db.Genres.ToList();
                ViewBag.types = db.Types.ToList();
                ViewBag.localizations = db.Localizations.ToList();
                ViewBag.platforms = db.Platforms.ToList();
                ViewBag.titles = db.Titles.ToList();
            }

            return View();
        }

        public int AddParameterToBD(int type, string content)
        {
            using (var db = new GamesWebAppDbContext())
            {
                switch (type)
                {
                    case 0: // Жанр
                        Genre genre = new Genre();
                        genre.GenreName = content;
                        db.Genres.Add(genre);
                        db.SaveChanges();
                        db.Entry(genre).GetDatabaseValues();
                        return genre.GenreId;
                    case 1: // Разработчик
                        Developer developer = new Developer();
                        developer.DeveloperName = content;
                        db.Developers.Add(developer);
                        db.SaveChanges();
                        db.Entry(developer).GetDatabaseValues();
                        return developer.DeveloperId;
                    case 2: // Издатель
                        Publisher publisher = new Publisher();
                        publisher.PublisherName = content;
                        db.Publishers.Add(publisher);
                        db.SaveChanges();
                        db.Entry(publisher).GetDatabaseValues();
                        return publisher.PublisherId;
                    case 3: // Серия
                        Title title = new Title();
                        title.TitleName = content;
                        db.Titles.Add(title);
                        db.SaveChanges();
                        db.Entry(title).GetDatabaseValues();
                        return title.TitleId;
                    case 4: // Платформа
                        Platform platform = new Platform();
                        platform.Platform1 = content;
                        db.Platforms.Add(platform);
                        db.SaveChanges();
                        db.Entry(platform).GetDatabaseValues();
                        return platform.PlatformId;
                    case 5: // Локализация
                        Localization localization = new Localization();
                        localization.Localization1 = content;
                        db.Localizations.Add(localization);
                        db.SaveChanges();
                        db.Entry(localization).GetDatabaseValues();
                        return localization.LocalizationId;
                }
            }
            return -1;
        }

        public int AddGameToDB(GameToAdd igame)
        {
            using (var db = new GamesWebAppDbContext())
            {
                var file = igame.LogoImage;
                if (file.Length > 0)
                {
                    Game game = new Game();

                    game.GameName = igame.GameName;
                    game.GameReleaseDate = igame.GameReleaseDate;
                    game.GamePublisher = igame.GamePublisher;
                    game.GamePegi = igame.GamePegi;
                    game.GameTitle = igame.GameTitle;
                    game.GameDescription = igame.GameDescription;

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        game.GameLogo = fileBytes;
                    }

                    db.Games.Add(game);

                    db.SaveChanges();

                    db.Entry(game).GetDatabaseValues();

                    return game.GameId;
                }
                return -1;
            }
        }

        public void AddGameinfo(int type, int forGameId, int value)
        {
            using (var db = new GamesWebAppDbContext())
            {
                switch (type)
                {
                    case 0: // Тип
                        GameType gameType = new GameType();
                        gameType.GameId = forGameId;
                        gameType.TypeId = value;
                        db.GameTypes.Add(gameType);
                        break;
                    case 1: // Жанр
                        GameGenre gameGenre = new GameGenre();
                        gameGenre.GameId = forGameId;
                        gameGenre.GenreId = value;
                        db.GameGenres.Add(gameGenre);
                        break;
                    case 2: // Разработчик
                        GameDeveloper gameDeveloper = new GameDeveloper();
                        gameDeveloper.GameId = forGameId;
                        gameDeveloper.DeveloperId = value;
                        db.GameDevelopers.Add(gameDeveloper);
                        break;
                    case 3: // Платформа
                        GamePlatform gamePlatform = new GamePlatform();
                        gamePlatform.GameId = forGameId;
                        gamePlatform.PlatformId = value;
                        db.GamePlatforms.Add(gamePlatform);
                        break;
                    case 4: // Локализация
                        GameLocalization gameLocal = new GameLocalization();
                        gameLocal.GameId = forGameId;
                        gameLocal.LocalizationId = value;
                        db.GameLocalizations.Add(gameLocal);
                        break;
                }
                db.SaveChanges();
            }
        }

        public void AddComment(int gameId, string username, string content, int rating)
        {
            using (var db = new GamesWebAppDbContext())
            {
                int userId = (from u in db.Users
                              where u.UserName == username
                              select u.UserId
                            ).Single();

                Comment comment = new Comment();
                comment.CommentGame = gameId;
                comment.CommentUser = userId;
                comment.CommentContent = content;
                comment.CommentRating = rating;

                db.Comments.Add(comment);
                db.SaveChanges();
            }
        }

    }
}
