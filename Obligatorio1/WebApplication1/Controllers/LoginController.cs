using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        private int maximo_intentos = 3;

        [HttpGet]
        public IActionResult Ingresar()
        {
            if (HttpContext.Session.GetInt32("intentosFallidos") == null)
            {
                HttpContext.Session.SetInt32("intentosFallidos", 0);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string email, string password)
        {
            try
            {
                int intentosFallidos = HttpContext.Session.GetInt32("intentosFallidos") ?? 0;

                if (intentosFallidos >= maximo_intentos)
                {
                    ViewBag.Mensaje = "Has superado el límite de intentos permitidos. Por favor, intenta más tarde.";
                    ViewBag.BloquearFormulario = true;
                    return View();
                }

                Usuario unS = _sistema.obtenerUsuario(email, password);
                if (unS == null)
                {
                    intentosFallidos++;
                    HttpContext.Session.SetInt32("intentosFallidos", intentosFallidos);

                    if (intentosFallidos >= maximo_intentos)
                    {
                        ViewBag.Mensaje = "Has superado el límite de intentos permitidos. Por favor, intenta más tarde.";
                        ViewBag.BloquearFormulario = true;
                    }
                    else
                    {
                        ViewBag.Mensaje = $"Credenciales no válidas. Te quedan {maximo_intentos - intentosFallidos} intentos.";
                    }
                    return View();
                }

                HttpContext.Session.SetInt32("intentosFallidos", 0);

                if (unS.rol() == "Admin")
                {
                    HttpContext.Session.SetString("rol", unS.rol());
                    HttpContext.Session.SetString("UserName", unS.Email);
                    HttpContext.Session.SetString("password", unS.Contrasenia);
                    return Redirect("/Subasta/index");
                }

                if (unS.rol() == "Cliente")
                {
                    HttpContext.Session.SetString("rol", unS.rol());
                    HttpContext.Session.SetString("UserName", unS.Email);
                    HttpContext.Session.SetString("password", unS.Contrasenia);
                    return Redirect("/Publicacion/index");
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Ingresar");
        }
    }
}