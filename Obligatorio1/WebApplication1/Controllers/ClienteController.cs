using Dominio;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using WebApplication1.Filtros;

namespace WebApplication1.Controllers
{
    [Logueado]
    public class ClienteController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.Clientes = _sistema.obtenerClientes();
            return View();
        }
        [HttpGet]
        public IActionResult Cargarsaldo()
        {
            string email = HttpContext.Session.GetString("UserName");
            string password = HttpContext.Session.GetString("password");
            Cliente clienteACargar = _sistema.obtenerClienteByEmailAndPassword(email, password);
            ViewBag.saldoActual = clienteACargar.Saldo;
            return View();
        }

        [HttpPost]
        public IActionResult Cargarsaldo(double saldo)
        {
            if (saldo > 0 && !double.IsNaN(saldo) && !double.IsNegative(saldo))
            {
                string email = HttpContext.Session.GetString("UserName");
                string password = HttpContext.Session.GetString("password");
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    Cliente clienteACargar = _sistema.obtenerClienteByEmailAndPassword(email, password);
                    ViewBag.saldoActual = clienteACargar.Saldo;
                    clienteACargar.SumarSaldo(saldo);

                    ViewBag.NuevoSaldo = $"Tu nuevo saldo es ${clienteACargar.Saldo}";
                }
            }
            else
            {
                ViewBag.saldoInvalido = $"Tu saldo ingresado: {saldo} debe ser numero y mayor a 0";
            }
            return View();
        }
    }
}