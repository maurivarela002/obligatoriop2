using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
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
			try
			{
				Usuario unS = _sistema.obtenerUsuario(email, password);
				if (unS == null)
				{
					throw new Exception("Credenciales no validas");
				}

				if (unS.rol()=="Admin")
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
				ViewBag.mensaje = e.Message;
			}
			return Redirect("/Login/Ingresar");
		}


		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Ingresar");
		}


	}
}