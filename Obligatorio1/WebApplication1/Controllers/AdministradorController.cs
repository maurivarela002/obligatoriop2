using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdministradorController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.Administradores = _sistema.obtenerAdministradores();
            return View();
        }
    }
}
