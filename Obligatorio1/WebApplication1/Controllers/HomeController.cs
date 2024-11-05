using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult IrALogin()
        {
            return RedirectToAction("Ingresar", "Login");
        }

        public IActionResult IrARegistro()
        {
            return RedirectToAction("Registrar", "Registrarse");
        }
    }
} 