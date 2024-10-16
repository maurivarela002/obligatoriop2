using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ArticuloController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public string Listado() {

            return "Aca se van a listar los articulos";
        }
    }
}
