using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string user)
        {
            HttpContext.Session.SetString("user", user);
            return Redirect("/cliente/index");
        }

    }
}
