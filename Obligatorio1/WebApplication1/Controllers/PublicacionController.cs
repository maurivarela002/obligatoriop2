using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class PublicacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
