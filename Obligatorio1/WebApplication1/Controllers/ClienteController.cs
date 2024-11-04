using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.Clientes = _sistema.obtenerClientes();
            return View();
        }

        public IActionResult cargarsaldo()
        {
            ViewBag.Clientes = _sistema.obtenerClientes();
            return View();
        }
    }
}