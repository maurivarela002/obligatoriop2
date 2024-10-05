

using Dominio;
using Dominio.Entidades;

namespace AppTest
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            _sistema.PrecargarDatos();

            int opcion = 0;
            do
            {
                MostrarTitulo("Menu");
                opcion = PedirNumero(
                    "Ingrese la opción\n" +
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
                        //ListarArticulo();
                        ListarCategoria();
                        break;
                    case 3:
                        AltaArticulo();
                        break;
                    case 4:
                        ListarVentas();
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



        private static void ListarClientes()
        {
            MostrarTitulo("Listado de Clientes");

            //recorro _clientes y muestro el campo que quiera de toda su clase
            foreach (var cliente in _sistema.Clientes)
            {
                Console.WriteLine(cliente.ToString());
            }
        }

        //private static void ListarAdministradores()
        //{
        //    MostrarTitulo("Listado de Administradores");

        //    //recorro _administrador y muestro el campo que quiera de toda su clase
        //    foreach (var administrador in _sistema.Administradores)
        //    {
        //        Console.WriteLine(administrador.ToString());
        //    }
        //}

        //private static List<Articulo> ListarArticulo()
        //{
        //    List<Articulo> aux = new List<Articulo>();
        //    foreach (var art in _sistema.Articulos)
        //    {
        //        aux.Add(art);
        //    }

        //    return aux;
        //}




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
        private static void ListarVentas()
        {
            foreach (Venta unaVenta in _sistema.Ventas)
            {
                Console.WriteLine(unaVenta);
                Console.WriteLine("Los articulos de la venta son: ");
                foreach (Articulo unart in _sistema.ArticulosxNombrePublicacion(unaVenta.Nombre))
                { Console.WriteLine($"->{unart.NombreArt}"); }
            }

        }


    }

}
