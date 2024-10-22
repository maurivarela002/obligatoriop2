using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        private Sistema _sistema = new Sistema();
        public IActionResult Index()
        {
            ViewBag.Clientes = _sistema.obtenerClientes();
            return View();
        }
    }
}