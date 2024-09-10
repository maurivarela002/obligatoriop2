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
                Console.WriteLine("Biemvenido al obligatorio!");

                Cliente primerCliente = new Cliente("Mauricio");
                _sistema.AgregarCliente(primerCliente);

                Console.WriteLine(_sistema.BuscarClientes("Mauricio"));

            }
            catch (Exception err) { 
                Console.WriteLine(err.Message);
            }
            
        }
    }
}
