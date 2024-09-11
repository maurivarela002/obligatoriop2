using Dominio;
using Dominio.Entidades;

namespace AppTest
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            try
            {
                Cliente primerCliente = new Cliente(10000, "Cliente", "Cliente", "cliente@gmail.com", "******");
                _sistema.AgregarCliente(primerCliente);

                Administrador primerAdministrador = new Administrador("Admin", "Admin", "admin@gmail.com", "******");
                _sistema.AgregarAdministrador(primerAdministrador);

                Console.WriteLine(_sistema.BuscarClientes("Cliente"));
                Console.WriteLine(_sistema.BuscarAdministradores("Admin"));


            }
            catch (Exception err) { 
                Console.WriteLine(err.Message);
            }
            
        }
    }
}
