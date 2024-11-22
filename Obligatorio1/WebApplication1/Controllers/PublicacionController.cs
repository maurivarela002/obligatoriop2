using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filtros;

namespace WebApplication1.Controllers
{
	[Logueado]
	public class PublicacionController : Controller
	{
		private Sistema _sistema = Sistema.Instancia;
		public IActionResult Index(string mensaje)
		{
			ViewBag.mensaje = mensaje;
			ViewBag.Publicacion = _sistema.Publicaciones;
			string email = HttpContext.Session.GetString("UserName");
			string password = HttpContext.Session.GetString("password");
			Cliente clienteACargar = _sistema.obtenerClienteByEmailAndPassword(email, password);
			ViewBag.Saldoactual = clienteACargar.Saldo;

			return View();
		}
		public IActionResult VerArticulos(string nombrePublicacion)
		{
			ViewBag.publiName = _sistema.obtenerPublicacion(nombrePublicacion);
			ViewBag.publicacion = _sistema.ArticulosxNombrePublicacion(nombrePublicacion);
			return View();
		}

		public IActionResult compraOferta(string nombrePublicacion)
		{
			string mensaje = "";
			Publicacion unaP = _sistema.obtenerPublicacion(nombrePublicacion);
			double precioPublicacion = unaP.PrecioPublicacion();
			if (unaP.Tipo() == "Venta")
			{
				string email = HttpContext.Session.GetString("UserName");
				string password = HttpContext.Session.GetString("password");
				Cliente cliente = _sistema.obtenerClienteByEmailAndPassword(email, password);

				if (cliente.Saldo > precioPublicacion)
				{
					mensaje = "Compra realizada con exito!!";
					cliente.Saldo = cliente.Saldo - precioPublicacion;
					return RedirectToAction("Index", new { mensaje });
				}
				else 
				{
					mensaje = "Saldo Insuficiente!!";
					return RedirectToAction("Index", new { mensaje });
				}
			}

			return Redirect($"/oferta/Index?nombrePublicacion={unaP.Nombre}");
		}

	}
}
