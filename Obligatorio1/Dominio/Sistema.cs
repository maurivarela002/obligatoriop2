using Dominio.Entidades;
namespace Dominio
{
    public class Sistema
    {
        private List<Cliente> _cliente = new List<Cliente>();

        public void AgregarCliente(Cliente cliente)
        {
            if (cliente == null) throw new Exception("Debe tener un valor!");
            cliente.Validar();
            _cliente.Add(cliente);

        }

        public Cliente BuscarClientes(string nombre)
        {
            Cliente? clienteEncontrado = null;
            foreach (Cliente i in _cliente)
            {
                clienteEncontrado = i.Nombre == nombre ? i : null;
            }
            return clienteEncontrado;
        }

        public List<Cliente> Clientes { get { return _cliente; } }
    }

}
