using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ArticuloController : Controller
    {
        private Sistema _sistema = new Sistema();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Articulo = _sistema.Articulos;
            return View();
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

