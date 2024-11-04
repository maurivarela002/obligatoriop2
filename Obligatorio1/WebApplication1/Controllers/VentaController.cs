using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class VentaController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {

            return View();
        }
    }
}
