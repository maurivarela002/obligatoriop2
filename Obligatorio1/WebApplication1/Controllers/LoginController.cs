using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string email, string password)
        {
            bool existe = false;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                existe = _sistema.ClienteExiste(email, password);
                if (existe)
                {
                    HttpContext.Session.SetString("email", email);
                    HttpContext.Session.SetString("password", password);
                    //HttpContext.Session.SetString("admin", admin);
                }
                else
                {
                    ViewBag.Mensaje = "El usuario que intentas ingresar no se encuentra en nuestro sistema.";
                }
            }
            return existe ? Redirect("/Publicacion/Index") : View();
        }
    }
}