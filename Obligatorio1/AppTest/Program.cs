

using Dominio;
using Dominio.Entidades;
namespace AppTest
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        private static DateTime fecha;

        static void Main(string[] args)
        {
            _sistema.PrecargarDatos();

            int opcion = 0;
            do
            {
                MostrarTitulo("Menu");
                opcion = PedirNumero(
                    "Ingrese una opción\n" +
                    "1-Listar Clientes\n" +
                    "2-Listar Categoria\n" +
                    "3-Alta de Articulo\n" +
                    "4-Listar Publicaciones\n" +
                    "0-salir");
                switch (opcion)
                {
                    case 1:
                        ListarClientes();
                        break;
                    case 2:
                        ListarCategoria();
                        break;
                    case 3:
                        AltaArticulo();
                        break;
                    case 4:
                        Console.WriteLine("Ingrese una fecha de inicio");
                        DateTime f1 = PedirFecha();
                        Console.WriteLine("Ingrese una fecha de fin");
                        DateTime f2 = PedirFecha();
                        ListarPublicaciones(f1, f2);
                        break;
                    default:
                        break;
                }
            }
            while (opcion != 0);
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
                    Console.WriteLine("Advertencia: Este campo no puede estar vacio");
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
            // Repetir hasta que el usuario ingrese una fecha válida
            while (!esFechaValida)
            {
                Console.WriteLine("Por favor, ingrese una fecha (formato: dd/MM/yyyy):");
                string entrada = Console.ReadLine();
                // Intentar convertir la entrada en un DateTime
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
        private static void ListarClientes()
        {
            MostrarTitulo("Listado de Clientes");
            foreach (var cliente in _sistema.Clientes)
            {
                Console.WriteLine(cliente.ToString());
            }
        }
        private static void ListarCategoria()
        {
            string categoria = PedirString("Ingrese unca categoria");
            foreach (var art in _sistema.Articulos)
            {
                if (art.Categoria.ToUpper() == categoria.ToUpper())
                {
                    Console.WriteLine(art.ToString());
                }
            }
        }
        private static void AltaArticulo()
        {
            string nombre = PedirString("Ingrese el nombre del articulo");
            string categoria = PedirString("Ingrese la categoria");
            int precio = PedirNumero("Ingrese el precio de venta");
            _sistema.AgregarArticulo(new Articulo(nombre, categoria, precio));
        }
        private static void ListarVentas(DateTime fechainicio, DateTime fechafin)
        {
            foreach (Venta unaVenta in _sistema.Ventas)
            {
                if (unaVenta.FchPublic >= fechainicio && unaVenta.FchPublic <= fechafin)
                {
                    Console.WriteLine(unaVenta);
                    Console.WriteLine("Los articulos en venta son: ");
                    foreach (Articulo unart in _sistema.ArticulosxNombrePublicacion(unaVenta.Nombre))
                    { Console.WriteLine($"->{unart.NombreArt} -- precio: {unart.PrecioVenta}"); }
                }
            }
        }
        private static void ListarSubastas(DateTime fechainicio, DateTime fechafin)
        {
            foreach (Subasta unaSubasta in _sistema.Subastas)
            {
                if (unaSubasta.FchPublic >= fechainicio && unaSubasta.FchPublic <= fechafin)
                {
                    Console.WriteLine(unaSubasta);
                    Console.WriteLine("Los articulos subastados son: ");
                }
                foreach (Articulo unart in _sistema.ArticulosxNombrePublicacion(unaSubasta.Nombre))
                { 
                    Console.WriteLine($"->{unart.NombreArt}"); 
                }
            }
        }
        private static void ListarPublicaciones(DateTime fechainicio, DateTime fechafin)
        {
            ListarVentas(fechainicio, fechafin);
            ListarSubastas(fechainicio, fechafin);
        }
    }
}
