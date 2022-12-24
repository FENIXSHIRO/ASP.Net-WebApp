using Microsoft.AspNetCore.Mvc;
using ComputerGames.Models;

namespace ComputerGames.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult Show(int id)
        {
            byte[] imageData;

            using (var db = new GamesWebAppDbContext())
            {
                var image = db.Games.FirstOrDefault(i => i.GameId == id);
                imageData = image.GameLogo;
            }

            return File(imageData, "image/jpg");
        }

        public ActionResult GetScreenshotByNumber(int gameId, int numberOfScreenshot)
        {
            byte[] imageData;

            using (var db = new GamesWebAppDbContext())
            {
                var images = (from s in db.Screenshots
                              where s.GameId == gameId
                              select s.ScreenshotData
                            ).ToList();

                imageData = images[numberOfScreenshot];
            }

            return File(imageData, "image/jpg");
        }
    }
}
