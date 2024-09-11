using Dominio.Entidades;
namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuario = new List<Usuario>();
        private List<Cliente> _cliente = new List<Cliente>();
        private List<Administrador> _administrador = new List<Administrador>();


        public void AgregarCliente(Cliente cliente)
        {
            if (cliente == null) throw new Exception("Debe tener un valor!");
            cliente.Validar();
            _cliente.Add(cliente);
        }

        public void AgregarAdministrador(Administrador administrador)
        {
            if (administrador == null) throw new Exception("Debe tener un valor!");
            administrador.Validar();
            _administrador.Add(administrador);
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

        public Administrador BuscarAdministradores(string nombre)
        {
            Administrador? adminEncontrado = null;
            foreach (Administrador i in _administrador)
            {
                adminEncontrado = i.Nombre == nombre ? i : null;
            }
            return adminEncontrado;
        }

        public List<Cliente> Clientes { get { return _cliente; } }
        public List<Administrador> Administrador { get { return _administrador; } }

    }

}
