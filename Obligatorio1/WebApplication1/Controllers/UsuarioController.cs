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
            ViewBag.Admin = false;
            ViewBag.Clientes = _sistema.obtenerClientes();
            ViewBag.Administradores = _sistema.obtenerAdministradores();

            if (ViewBag.Admin == false)
                return Redirect("/Publicacion/index");
            else
                return Redirect("/Administrador/index");
        }
    }

}
