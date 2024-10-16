using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = new Sistema();
        public IActionResult Index()
        {
            return View();
        }
    }

}
