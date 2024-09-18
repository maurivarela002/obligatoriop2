using Dominio;
using Dominio.Entidades;

namespace obligatorio1
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            PrecargarDatos();

            int opcion = 0;
            do
            {
                MostrarTitulo("Menu");
                opcion = PedirNumero(
                    "Ingrese la opción\n" +
                    "1-Alta Cliente\n" +
                    "2-Alta Administrador\n" +
                    "3-Listar Cliente\n" +
                    "4-Listar Administrador\n" +
                    "0-salir");
                switch (opcion)
                {
                    case 1:
                        //ListarClientes();
                        break;
                    case 2:
                        //ListarCategoria();
                        break;
                    case 3:
                        ListarClientes();
                        break;
                    case 4:
                        ListarAdministradores();
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

        private static void ListarClientes()
        {
            MostrarTitulo("Listado de Clientes");

            //recorro _clientes y muestro el campo que quiera de toda su clase
            foreach (var cliente in _sistema.Clientes)
            {
                Console.WriteLine(cliente.ToString());
            }
        }

        private static void ListarAdministradores()
        {
            MostrarTitulo("Listado de Administradores");

            //recorro _administrador y muestro el campo que quiera de toda su clase
            foreach (var administrador in _sistema.Administradores)
            {
                Console.WriteLine(administrador.ToString());
            }
        }
        private static void ListarCategoria() { }
        private static void AgregarArticulo() { }
        private static void PublicacionesEntre() { }



        //Precarga
        private static void PrecargarDatos()
        {
            _sistema.AgregarCliente(new Cliente("Juan", "Pérez", "juan.perez@mail.com", "password1", 1000));
            _sistema.AgregarCliente(new Cliente("Ana", "Gómez", "ana.gomez@mail.com", "password2", 1500));
            _sistema.AgregarCliente(new Cliente("Carlos", "Lopez", "carlos.lopez@mail.com", "password3", 2000));

            _sistema.AgregarAdministrador(new Administrador("Marta", "Suarez", "marta.suarez@mail.com", "admin1"));
            _sistema.AgregarAdministrador(new Administrador("Luis", "Ramirez", "luis.ramirez@mail.com", "admin2"));
            _sistema.AgregarAdministrador(new Administrador("Sofia", "Martinez", "sofia.martinez@mail.com", "admin3"));
        }
    }

}
