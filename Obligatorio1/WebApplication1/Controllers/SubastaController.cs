using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filtros;

namespace WebApplication1.Controllers
{
    //[Admin]
    public class SubastaController : Controller
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
			ViewBag.publiName = _sistema.obtenerPublicacion(nombrePublicacion);
			ViewBag.publicacion = _sistema.ArticulosxNombrePublicacion(nombrePublicacion);
			return View();
        }
        public IActionResult cerrarSubasta(string nombreSubasta) 
        {
            string mensaje = _sistema.CerrarSubasta(nombreSubasta);
			ViewBag.publiName = _sistema.obtenerPublicacion(nombreSubasta);
			ViewBag.publicacion = _sistema.ArticulosxNombrePublicacion(nombreSubasta);
            //ViewBag.oferente = _sistema.obteneroferente(_sistema.obtenerPublicacion(nombreSubasta));

			return RedirectToAction("index", new { mensaje });
		}





	}
}
