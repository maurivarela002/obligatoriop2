using Dominio.Entidades;
namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Cliente> _clientes = new List<Cliente>();
        private List<Administrador> _administradores = new List<Administrador>();
        private List<Subasta> _subastas = new List<Subasta>();
        private List<Venta> _ventas = new List<Venta>();


        public enum EnumEstados
        { 
        ABIERTA,
        CERRADA,
        CANCELADA


        }

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
        }

        public List<Publicacion> Publicaciones
        {
            get { return _publicaciones; }
        }

        public List<Articulo> Articulos
        {
            get { return _articulos; }
        }

        public List<Cliente> Clientes
        {
            get { return _clientes; }
        }

        public List<Administrador> Administradores
        {
            get { return _administradores; }
        }

        public List<Subasta> Subastas
        {
            get { return _subastas; }
        }

        public List<Venta> Ventas
        {
            get { return _ventas; }
        }




        public void AgregarCliente(Cliente cliente)
        {
            if (cliente == null) throw new Exception("Debe tener un valor!");
            cliente.Validar();
            _clientes.Add(cliente);
        }

        public Cliente BuscarClientes(string nombre)
        {
            Cliente? clienteEncontrado = null;
            foreach (Cliente i in _clientes)
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
            _administradores.Add(administrador);
        }

        public Administrador BuscarAdministrador(string nombre)
        {
            Administrador? adminEncontrado = null;
            foreach (Administrador i in _administradores)
            {
                adminEncontrado = i.Nombre == nombre ? i : null;
            }
            return adminEncontrado;
        }



        public void AgregarArticulo(Articulo articulo)
        {
            if (articulo == null) throw new Exception("El articulo cargado es nulo");
            articulo.Validar();
            _articulos.Add(articulo);


        }


        public void AgregarSubasta(Subasta subasta)
        {
            if (subasta == null) throw new Exception("La carga de la subasta no puede esta vacia");
            subasta.Validar();
            _subastas.Add(subasta);
        }

        public void AgregarVenta(Venta venta)
        {
            if (venta == null) throw new Exception("La carga de la venta no puede ser nula");
            venta.Validar();
            _ventas.Add(venta);
        }


        public void PrecargarDatos()
        {
            //Precarga de clientes
            AgregarCliente(new Cliente("Juan", "Pérez", "juan.perez@mail.com", "password1", 1000));
            AgregarCliente(new Cliente("Ana", "Gómez", "ana.gomez@mail.com", "password2", 1500));
            AgregarCliente(new Cliente("Carlos", "Lopez", "carlos.lopez@mail.com", "password3", 2000));

            //Precarga de Administradores
            AgregarAdministrador(new Administrador("Marta", "Suarez", "marta.suarez@mail.com", "admin1"));
            AgregarAdministrador(new Administrador("Luis", "Ramirez", "luis.ramirez@mail.com", "admin2"));
            AgregarAdministrador(new Administrador("Sofia", "Martinez", "sofia.martinez@mail.com", "admin3"));

            //Precarga de articulos
            AgregarArticulo(new Articulo("Balde", "playa", 350));
            AgregarArticulo(new Articulo("sombrilla", "playa", 150));
            AgregarArticulo(new Articulo("protector solar", "playa", 400));
            AgregarArticulo(new Articulo("salvavidas", "playa", 110));
            AgregarArticulo(new Articulo("Bicicleta de carrera", "ciclismo", 15000));

            //Precarga de Subastas
            //AgregarSubasta(new Subasta("Vuelta ciclista", "ABIERTA", new DateTime(2024, 09, 01, 00, 00, 00),, 1235, new DateTime(2024, 09, 24, 00, 00, 00)));



            //Precargas de ventas
            //_sistema.AgregarVenta(new Venta());


        }

    }
}
