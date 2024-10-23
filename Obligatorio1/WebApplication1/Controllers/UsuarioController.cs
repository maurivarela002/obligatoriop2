using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.Usuarios = _sistema.Usuarios;
            ViewBag.Admin = true;
            ViewBag.Clientes = _sistema.obtenerClientes();
            ViewBag.Administradores = _sistema.obtenerAdministradores();

            if (ViewBag.Admin == true)
                return Redirect("/Publicacion/index");
            else
                return View();
        }
    }

}
