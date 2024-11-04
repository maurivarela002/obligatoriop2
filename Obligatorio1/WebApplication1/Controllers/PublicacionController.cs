using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            ViewBag.Publicacion = _sistema.Publicaciones;
            return View();
        }
        public IActionResult VerArticulos(string nombrePublicacion)
        {
            ViewBag.publiName =_sistema.obtenerPublicacion(nombrePublicacion);
			ViewBag.publicacion = _sistema.ArticulosxNombrePublicacion(nombrePublicacion);
            return View();
        }



    }
}
