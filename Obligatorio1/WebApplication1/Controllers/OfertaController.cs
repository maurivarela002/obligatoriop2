using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class OfertaController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string nombrePublicacion)
        {
			//ViewBag.NombrePublicacion = _sistema.obtenerPublicacion(nombrePublicacion);
			ViewBag.Oferta = _sistema.OfertasxNombrePublicacion(nombrePublicacion);

			return View();
        }
    }
}
