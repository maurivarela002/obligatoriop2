using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ArticuloController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Articulo = _sistema.Articulos;
            return View();
        }

        public IActionResult verArticulos(string nombrePublicacion)
        {
            return View(_sistema.ArticulosxNombrePublicacion(nombrePublicacion));
        }
        [HttpGet]
        public IActionResult GestionArticulo()
        {
            ViewBag.Articulo = _sistema.Articulos;
            return View();
        }

        [HttpPost]
        public IActionResult GestionArticulo(Articulo articulo)
        {
            ViewBag.Articulo = _sistema.Articulos;
            _sistema.AgregarArticulo(articulo);
            ViewBag.Mensaje = $"Artículo {articulo.NombreArt} creado exitosamente.";

            return View();
        }
    }
}

