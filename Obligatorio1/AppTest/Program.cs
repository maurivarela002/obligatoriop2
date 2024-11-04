

using Dominio;
using Dominio.Entidades;
namespace AppTest
{
	internal class Program
	{
		static Sistema _sistema = Sistema.Instancia;
		//static Sistema _sistema = new Sistema();
		private static DateTime fecha;
		static void Main(string[] args)
		{
			//Validar antes de recorrer listas, que pasa si estan vacias

			int opcion = 0;
			do
			{
				MostrarTitulo("Menu");
				opcion = PedirNumero(
					"Ingrese una opción\n" +
					"1-Realizar precarga\n" +
					"2-Listar Clientes\n" +
					"3-Listar Categoria\n" +
					"4-Alta de Articulo\n" +
					"5-Listar Publicaciones\n" +
					"0-salir");
				switch (opcion)
				{
					case 1:
						//_sistema.testRndom();
						break;
					case 2:
						//ListarClientes();
						break;
					case 3:
						ListarCategoria();
						break;
					case 4:
						AltaArticulo();
						break;
					case 5:
						ListarPublicaciones();
						break;
					default:
						break;
				}
			}
			while (opcion != 0);
		}
		private static void HacerPrecaraga()
		{
			try
			{
				_sistema.PrecargarDatos();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		private static void MostrarTitulo(string mensaje)
		{
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("");
			Console.WriteLine(mensaje);
			Console.WriteLine("");
			Console.BackgroundColor = ConsoleColor.Black;
		}

		private static int PedirNumero(string mensaje)
		{
			int numero = 0;
			bool seguir = false;
			do
			{
				try
				{
					Console.WriteLine(mensaje);
					numero = int.Parse(Console.ReadLine());
					seguir = false;
				}
				catch (Exception)
				{
					Console.WriteLine("Solo debe ingresar numeros.");
					seguir = true;
				}

			} while (seguir);
			return numero;
		}

		private static string PedirString(string mensaje)
		{
			string respuesta;
			bool seguir = false;
			do
			{

				Console.WriteLine(mensaje);
				respuesta = Console.ReadLine();
				if (String.IsNullOrEmpty(respuesta))
				{
					throw new Exception("Advertencia: Este campo no puede estar vacio");
					seguir = true;
				}
				else
				{ seguir = false; }
			} while (seguir);
			return respuesta;
		}
		public static DateTime PedirFecha()
		{
			DateTime fecha;
			bool esFechaValida = false;
			while (!esFechaValida)
			{
				Console.WriteLine("Por favor, ingrese una fecha (formato: dd/MM/yyyy):");
				string entrada = Console.ReadLine();
				if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
				{
					esFechaValida = true;
					return DateTime.Parse(entrada);
				}
				else
				{
					Console.WriteLine("Formato de fecha incorrecto. Inténtelo nuevamente.");
				}
			}
			return DateTime.Now;
		}
		private static void ListarCategoria()
		{
			try
			{
				if (_sistema.Articulos.Count() > 0)
				{
					string categoria = PedirString("Ingrese una categoria");
					string salida = "No se encontraro esa categoria";
					foreach (var art in _sistema.Articulos)
					{
						//hacer en sistema
						if (art.Categoria.ToUpper() == categoria.ToUpper())
						{
							salida = art.ToString();
						}
					}

					Console.WriteLine(salida);
				}
				else { Console.WriteLine("No hay categorias cargadas en el sistema"); }

			}
			catch (Exception e) { Console.WriteLine(e.ToString()); }
		}
		private static void AltaArticulo()
		{
			try
			{
				string nombre = PedirString("Ingrese el nombre del articulo");
				string categoria = PedirString("Ingrese la categoria");
				int precio = PedirNumero("Ingrese el precio de venta");
				_sistema.AgregarArticulo(new Articulo(nombre, categoria, precio));
			}
			catch (Exception e) { Console.WriteLine(e.Message); };
		}
		private static void ListarPublicaciones()
		{
			try
			{


				foreach (Publicacion unP in _sistema.Publicaciones)
				{

					Console.WriteLine(unP);
					Console.WriteLine("Los articulos en venta son: ");
					foreach (Articulo unart in _sistema.ArticulosxNombrePublicacion(unP.Nombre))
					{ Console.WriteLine($"->{unart.NombreArt} -- precio: {unart.PrecioVenta}"); }

				}
			}
			catch (Exception e) { Console.WriteLine(e.Message); };
		}
	}
}
