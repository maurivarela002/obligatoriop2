using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
namespace WebApplication1.Controllers
{
    public class OfertaController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string nombrePublicacion, string mensaje, int tipo)
        {
            ViewBag.mensajeSalida = mensaje;
            ViewBag.tipo = tipo;
			ViewBag.NombrePublicacion = _sistema.obtenerPublicacion(nombrePublicacion);
			var ofertas = _sistema.OfertasxNombrePublicacion(nombrePublicacion)
                             .OrderByDescending(o => o.Monto)
                             .ToList();
			ViewBag.Ofertas = ofertas;
			ViewBag.OfertaMaxima = ofertas.FirstOrDefault();
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
            int tipo;

            if (oferta.Monto > 0 && !double.IsNaN(oferta.Monto) && !double.IsNegative(oferta.Monto) && unaP.PrecioPublicacion() < oferta.Monto)
            {
                DateTime today = DateTime.Today;
                _sistema.AgregarOferta(new Oferta(0,
                                                _sistema.obtenerClientesPorId(0),
                                                oferta.Monto,
                                                new DateTime(today.Year, today.Month, today.Day, 00, 0, 0),
                                                NombrePublicacion));

                string Mensaje1 = "¡Oferta realizada con éxito!";
                tipo = 1;
                return RedirectToAction("Index", new { nombrePublicacion = NombrePublicacion, mensaje = Mensaje1, tipo = 1});
            }
            tipo = 2;
            string Mensaje2 = "Oferta no realizada, por favor verifique el importe.";
            return RedirectToAction("Index", new { nombrePublicacion = NombrePublicacion, mensaje = Mensaje2 , tipo=2});
        }
    }
}
