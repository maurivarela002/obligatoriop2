using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace WebApplication1.Controllers
{
    public class OfertaController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string nombrePublicacion)
        {
			ViewBag.NombrePublicacion = _sistema.obtenerPublicacion(nombrePublicacion);
			ViewBag.Oferta = _sistema.OfertasxNombrePublicacion(nombrePublicacion);
            string email = HttpContext.Session.GetString("UserName");
            string password = HttpContext.Session.GetString("password");
            Cliente clienteACargar = _sistema.obtenerClienteByEmailAndPassword(email, password);
            ViewBag.saldoActual = clienteACargar.Saldo;
            return View();
        }

        [HttpGet]
        public IActionResult puja() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult puja(Oferta oferta, string NombrePublicacion)
        {

            Publicacion unaP = _sistema.obtenerPublicacion(NombrePublicacion);

            if (oferta.Monto > 0 && !double.IsNaN(oferta.Monto) && !double.IsNegative(oferta.Monto) && unaP.PrecioPublicacion() < oferta.Monto)
            {
                DateTime today = DateTime.Today;
                _sistema.AgregarOferta(new Oferta(0,
                                                  0,
                                                  oferta.Monto,
                                                  new DateTime(today.Year, today.Month, today.Day, 00, 0, 0),
                                                  unaP.Nombre));

                ViewBag.MensajeValido = "Oferta realizada con exito!!";
            }

            ViewBag.MensajeInvalido = "Oferta no realizada, por favor verifique el importe!";
                return View("Index");
        }
    }
}
