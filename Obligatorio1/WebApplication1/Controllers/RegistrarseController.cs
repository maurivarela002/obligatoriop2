using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class RegistrarseController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string nombre, string apellido, string email, string password, double saldo)
        {
            try 
            {
                Cliente nuevoCliente = new Cliente(nombre, apellido, email, password, saldo);
                _sistema.AgregarUsuario(nuevoCliente);
                ViewBag.Mensaje = $"Cliente {nombre} {apellido} registrado exitosamente.";
                return RedirectToAction("Ingresar", "Login");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}