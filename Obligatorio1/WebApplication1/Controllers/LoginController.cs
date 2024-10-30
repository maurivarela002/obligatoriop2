using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private Sistema _sistema = new Sistema();

        [HttpGet]
        public IActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string email, string password)
        {
            bool existe = false;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                existe = _sistema.ClienteExiste(email);
                if (existe)
                {
                    HttpContext.Session.SetString("email", email);
                    HttpContext.Session.SetString("password", password);
                }
                else
                {
                    ViewBag.Mensaje = "El usuario que intentas ingresar no se encuentra en nuestro sistema.";
                }
            }           
            return existe ? Redirect("/Cliente/Index") : View();
        }
    }
}