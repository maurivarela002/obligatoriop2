using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdministradorController : Controller
    {
        private Sistema _sistema = new Sistema();
        public IActionResult Index()
        {
            ViewBag.Administradores = _sistema.Administradores;
            return View();
        }
    }
}
