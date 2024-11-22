using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    public class OfertaController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string nombrePublicacion)
        {
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

            if (oferta.Monto > 0 && !double.IsNaN(oferta.Monto) && !double.IsNegative(oferta.Monto) && unaP.PrecioPublicacion() < oferta.Monto)
            {
                DateTime today = DateTime.Today;
                _sistema.AgregarOferta(new Oferta(0,
                                                _sistema.obtenerClientesPorId(0),
                                                oferta.Monto,
                                                new DateTime(today.Year, today.Month, today.Day, 00, 0, 0),
                                                NombrePublicacion));

                ViewBag.MensajeValido = "¡Oferta realizada con éxito!";
                return RedirectToAction("Index", new { nombrePublicacion = NombrePublicacion });
            }

            ViewBag.MensajeInvalido = "Oferta no realizada, por favor verifique el importe.";
            return RedirectToAction("Index", new { nombrePublicacion = NombrePublicacion });
        }
    }
}
