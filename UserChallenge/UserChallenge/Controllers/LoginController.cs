using Microsoft.AspNetCore.Mvc;
using UserChallenge.Data.DAL.Interfaces;

namespace UserChallenge.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            this._login = login;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserChallenge.Models.UserLogin user)
        {
            if (_login.GetUserLogin(user).Result)
            {
                return RedirectToAction("Index","User", new {redirected = true});
            }

            TempData["Mensaje"] = "El usuario no existe o las credenciales son inválidas.";
            return RedirectToAction("Index");
        }
    }
}
