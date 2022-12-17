using Microsoft.AspNetCore.Mvc;
using ComputerGames.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using ComputerGames.Helpers;

namespace ComputerGames.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnAction, string returnController)
        {

            using (var db = new GamesWebAppDbContext())
            {
                var userInf = (from usr in db.Users
                            join ug in db.Usergroups
                             on usr.UserGroup equals ug.UsergroupId
                            where usr.UserName == username
                            select new
                            {
                                username = username,
                                password = usr.UserPassword,
                                email = usr.UserEmail,
                                usergroup = ug.UsergroupName
                            }).Single();

                if (userInf != null && userInf.password == PasswordHasher.HashPassword(password))
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, userInf.usergroup),
                };

                    var claimsIdentity = new ClaimsIdentity(claims, "Login");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return returnAction == null ? RedirectToAction("Index", "Home") : RedirectToAction(returnAction, returnController);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
