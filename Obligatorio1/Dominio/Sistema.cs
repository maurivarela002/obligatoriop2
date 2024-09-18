using Dominio.Entidades;
namespace Dominio
{
    public class Sistema
    {
        //private List<Usuario> _usuarios = new List<Usuario>();
        //private List<Publicacion> _publicaciones = new List<Publicacion>();
        //private List<Articulo> _articulos = new List<Articulo>();
        private List<Cliente> _cliente = new List<Cliente>();
        private List<Administrador> _administrador = new List<Administrador>();


        //public List<Usuario> Usuarios 
        //{
        //    get { return _usuarios; }
        //}

        //public List<Publicacion> Publicaciones
        //{
        //    get { return _publicaciones; }
        //}

        //public List<Articulo> Articulos
        //{
        //    get { return _articulos; }
        //}

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


        //Metodos Administrador
        public void AgregarAdministrador(Administrador administrador)
        {
            if (administrador == null) throw new Exception("Debe tener un valor!");
            administrador.Validar();
            _administrador.Add(administrador);
        }

        public Administrador BuscarAdministrador(string nombre)
        {
            Administrador? adminEncontrado = null;
            foreach (Administrador i in _administrador)
            {
                adminEncontrado = i.Nombre == nombre ? i : null;
            }
            return adminEncontrado;
        }

        public List<Cliente> Clientes { get { return _cliente; } }
        public List<Administrador> Administradores { get { return _administrador; } }
    }
}
