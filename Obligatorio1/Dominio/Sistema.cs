﻿using Dominio.Entidades;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        //private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Cliente> _clientes = new List<Cliente>();
        private List<Administrador> _administradores = new List<Administrador>();
        private List<Subasta> _subastas = new List<Subasta>();
        private List<Venta> _ventas = new List<Venta>();
        private List<Oferta> _ofertas = new List<Oferta>();


        public enum EnumEstados
        {
            ABIERTA,
            CERRADA,
            CANCELADA
        }
        //public EnumEstados Estados { get; set; }

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
        }

        //public List<Publicacion> Publicaciones
        //{
        //    get { return _publicaciones; }
        //}

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
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
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

        public void AgregarOferta(Oferta oferta)
        {
            oferta.Validar();
            _ofertas.Add(oferta);

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

        public List<Articulo> ObtenerArtxCat(string pCategoria)
        {
            List<Articulo> aux = new List<Articulo>();

            foreach (Articulo unArticulo in _articulos)
            {
                if (unArticulo.Categoria.ToLower()== pCategoria.ToLower())
                {
                    aux.Add(unArticulo);    
                    
                }

            }
            return aux;

        }

        public List<Articulo> ArticulosxNombrePublicacion(string pNombre) 
        {
            List<Articulo> aux = new List<Articulo>();

            if (pNombre.ToLower() == "electro party")
                return ObtenerArtxCat("Electrónica");

            if (pNombre.ToLower() == "sport sale")
                return ObtenerArtxCat("Deportes");

            if (pNombre.ToLower() == "mega sale")
                return ObtenerArtxCat("Ropa");

            if (pNombre.ToLower() == "tech expo")
                return ObtenerArtxCat("Periféricos");

            if (pNombre.ToLower() == "gadget fest")
                return ObtenerArtxCat("Audio");

            if (pNombre.ToLower() == "book sales")
                return ObtenerArtxCat("Libros");

            if (pNombre.ToLower() == "work world")
                return ObtenerArtxCat("Oficina");

            if (pNombre.ToLower() == "mayor tranquilidad")
                return ObtenerArtxCat("Seguridad");

            if (pNombre.ToLower() == "luxury")
                return ObtenerArtxCat("Joyería");

            if (pNombre.ToLower() == "holiday deals")
                ObtenerArtxCat("Viaje");

            if (pNombre.ToLower() == "black friday")
                return ObtenerArtxCat("Accesorios");


            return aux;
        }
        public List<Oferta> ofertasxPublicacion(string pNombre) 
        { 
            List<Oferta> aux = new List<Oferta>();
            foreach (Oferta unaoferta in _ofertas)
            {
                if (unaoferta.Pnombre.ToLower() == "electro party")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "sport sale")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "mega sale")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "tech expo")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "gadget fest")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "book sales")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "work world")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "mayor tranquilidad")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "luxury")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "holiday deals")
                    aux.Add(unaoferta);

                if (unaoferta.Pnombre.ToLower() == "black friday")
                    aux.Add(unaoferta);

            }

            return aux;
        }



        public void PrecargarDatos()
        {
            //Precarga de  10 clientes
            AgregarCliente(new Cliente("Juan", "Pérez", "juan.perez@mail.com", "password1", 1000));
            AgregarCliente(new Cliente("Ana", "Gómez", "ana.gomez@mail.com", "password2", 1500));
            AgregarCliente(new Cliente("Carlos", "Lopez", "carlos.lopez@mail.com", "password3", 2000));
            AgregarCliente(new Cliente("María", "García", "maria.garcia@mail.com", "password1", 1500));
            AgregarCliente(new Cliente("Juan", "Pérez", "juan.perez@mail.com", "password2", 1000));
            AgregarCliente(new Cliente("Ana", "Sánchez", "ana.sanchez@mail.com", "password4", 2500));
            AgregarCliente(new Cliente("Pedro", "Martínez", "pedro.martinez@mail.com", "password5", 3000));
            AgregarCliente(new Cliente("Luis", "Gómez", "luis.gomez@mail.com", "password6", 1200));
            AgregarCliente(new Cliente("Laura", "Fernández", "laura.fernandez@mail.com", "password7", 1800));
            AgregarCliente(new Cliente("Jorge", "Díaz", "jorge.diaz@mail.com", "password8", 2200));

            //Precarga de 2 Administradores
            AgregarAdministrador(new Administrador("Marta", "Suarez", "marta.suarez@mail.com", "admin1"));
            AgregarAdministrador(new Administrador("Luis", "Ramirez", "luis.ramirez@mail.com", "admin2"));

            //Precarga de 50 articulos

            //promt en chatgpt utilizado
            //    crea 50 precargas en codigo c# para una clase articulo que tiene el siguiente constructor         public Articulo(string nombre, string categoria, int precioVenta) 
            //{
            //        Id = _ultimoId++;
            //        NombreArt = nombre;
            //        Categoria = categoria;
            //        PrecioVenta = precioVenta;
            //    }
            AgregarArticulo(new Articulo("Laptop", "Electrónica", 1200));
            AgregarArticulo(new Articulo("Smartphone", "Electrónica", 800));
            AgregarArticulo(new Articulo("Televisor", "Electrónica", 1000));
            AgregarArticulo(new Articulo("Cámara", "Fotografía", 500));
            AgregarArticulo(new Articulo("Micrófono", "Audio", 150));
            AgregarArticulo(new Articulo("Auriculares", "Audio", 90));
            AgregarArticulo(new Articulo("Teclado", "Periféricos", 50));
            AgregarArticulo(new Articulo("Mouse", "Periféricos", 30));
            AgregarArticulo(new Articulo("Monitor", "Periféricos", 200));
            AgregarArticulo(new Articulo("Impresora", "Oficina", 120));
            AgregarArticulo(new Articulo("Mesa", "Muebles", 250));
            AgregarArticulo(new Articulo("Silla", "Muebles", 120));
            AgregarArticulo(new Articulo("Lámpara", "Iluminación", 45));
            AgregarArticulo(new Articulo("Reloj", "Accesorios", 90));
            AgregarArticulo(new Articulo("Pulsera", "Joyería", 65));
            AgregarArticulo(new Articulo("Collar", "Joyería", 150));
            AgregarArticulo(new Articulo("Anillo", "Joyería", 300));
            AgregarArticulo(new Articulo("Chaqueta", "Ropa", 100));
            AgregarArticulo(new Articulo("Zapatos", "Ropa", 80));
            AgregarArticulo(new Articulo("Cartera", "Accesorios", 50));
            AgregarArticulo(new Articulo("Mochila", "Accesorios", 90));
            AgregarArticulo(new Articulo("Libro", "Libros", 20));
            AgregarArticulo(new Articulo("Revista", "Libros", 6));
            AgregarArticulo(new Articulo("Cuaderno", "Papelería", 4));
            AgregarArticulo(new Articulo("Bolígrafo", "Papelería", 2));
            AgregarArticulo(new Articulo("Ventilador", "Electrodomésticos", 80));
            AgregarArticulo(new Articulo("Plancha", "Electrodomésticos", 46));
            AgregarArticulo(new Articulo("Tostadora", "Electrodomésticos", 30));
            AgregarArticulo(new Articulo("Cafetera", "Electrodomésticos", 60));
            AgregarArticulo(new Articulo("Refrigerador", "Electrodomésticos", 900));
            AgregarArticulo(new Articulo("Estufa", "Electrodomésticos", 500));
            AgregarArticulo(new Articulo("Licuadora", "Electrodomésticos", 35));
            AgregarArticulo(new Articulo("Cámara de seguridad", "Seguridad", 200));
            AgregarArticulo(new Articulo("Candado", "Seguridad", 13));
            AgregarArticulo(new Articulo("Alarma", "Seguridad", 50));
            AgregarArticulo(new Articulo("Bicicleta", "Deportes", 400));
            AgregarArticulo(new Articulo("Balón", "Deportes", 20));
            AgregarArticulo(new Articulo("Raqueta", "Deportes", 80));
            AgregarArticulo(new Articulo("Guantes", "Deportes", 15));
            AgregarArticulo(new Articulo("Camiseta deportiva", "Ropa", 30));
            AgregarArticulo(new Articulo("Pantalones", "Ropa", 40));
            AgregarArticulo(new Articulo("Vestido", "Ropa", 70));
            AgregarArticulo(new Articulo("Gafas de sol", "Accesorios", 26));
            AgregarArticulo(new Articulo("Sombrero", "Accesorios", 16));
            AgregarArticulo(new Articulo("Maleta", "Viaje", 200));
            AgregarArticulo(new Articulo("Paraguas", "Accesorios", 10));
            AgregarArticulo(new Articulo("Batería portátil", "Electrónica", 40));
            AgregarArticulo(new Articulo("Altavoz Bluetooth", "Audio", 50));
            AgregarArticulo(new Articulo("Consola de videojuegos", "Electrónica", 300));


            //************Precarga Publicaciones ****************
            //Precarga 10 ventas 
            AgregarVenta(new Venta("Electro Party", EnumEstados.ABIERTA, new DateTime(2024, 10, 05, 00, 00, 00), ObtenerArtxCat("Electrónica"),0,0,new DateTime(2024,10,05,00,00,00),false));
            AgregarVenta(new Venta("Sport Sale", EnumEstados.ABIERTA, new DateTime(2024, 10, 05, 00, 00, 00), ObtenerArtxCat("Deportes"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), true));
            AgregarVenta(new Venta("Mega Sale", EnumEstados.ABIERTA, new DateTime(2024, 10, 06, 00, 00, 00), ObtenerArtxCat("Ropa"), 0, 0, new DateTime(2024, 10, 06, 00, 00, 00), false));
            AgregarVenta(new Venta("Tech Expo", EnumEstados.ABIERTA, new DateTime(2024, 10, 07, 00, 00, 00), ObtenerArtxCat("Periféricos"), 0, 0, new DateTime(2024, 10, 07, 00, 00, 00), true));
            AgregarVenta(new Venta("Gadget Fest", EnumEstados.ABIERTA, new DateTime(2024, 10, 08, 00, 00, 00), ObtenerArtxCat("Audio"), 0, 0, new DateTime(2024, 10, 08, 00, 00, 00), false));
            AgregarVenta(new Venta("Book Sales", EnumEstados.ABIERTA, new DateTime(2024, 10, 09, 00, 00, 00), ObtenerArtxCat("Libros"), 0, 0, new DateTime(2024, 10, 09, 00, 00, 00), true));
            AgregarVenta(new Venta("Work World", EnumEstados.ABIERTA, new DateTime(2024, 10, 10, 00, 00, 00), ObtenerArtxCat("Oficina"), 0, 0, new DateTime(2024, 10, 10, 00, 00, 00), false));
            AgregarVenta(new Venta("Mayor Tranquilidad", EnumEstados.ABIERTA, new DateTime(2024, 10, 11, 00, 00, 00), ObtenerArtxCat("Seguridad"), 0, 0, new DateTime(2024, 10, 11, 00, 00, 00), true));
            AgregarVenta(new Venta("Luxury", EnumEstados.ABIERTA, new DateTime(2024, 10, 12, 00, 00, 00), ObtenerArtxCat("Joyería"), 0, 0, new DateTime(2024, 10, 12, 00, 00, 00), false));
            AgregarVenta(new Venta("Holiday Deals", EnumEstados.ABIERTA, new DateTime(2024, 10, 13, 00, 00, 00), ObtenerArtxCat("Viaje"), 0, 0, new DateTime(2024, 10, 13, 00, 00, 00), true));
            AgregarVenta(new Venta("Black Friday", EnumEstados.ABIERTA, new DateTime(2024, 10, 14, 00, 00, 00), ObtenerArtxCat("Accesorios"), 0, 0, new DateTime(2024, 10, 14, 00, 00, 00), true));


            //Precargas de Ofertas
            AgregarOferta(new Oferta(0, 0, 150.20, new DateTime(2024, 10, 05, 00, 00, 00), "Luxury"));
            AgregarOferta(new Oferta(3, 3, 130.45, new DateTime(2024, 10, 05, 00, 00, 00), "Luxury"));
            AgregarOferta(new Oferta(1, 1, 100.99, new DateTime(2024, 10, 02, 00, 00, 00), "Holiday Deals"));
            AgregarOferta(new Oferta(2, 2, 120.10, new DateTime(2024, 10, 04, 00, 00, 00), "Black Friday"));


            //Precarga 10 subastas
            AgregarSubasta(new Subasta("Luxury", EnumEstados.ABIERTA, new DateTime(2024, 10, 01, 00, 00, 00), ObtenerArtxCat("Joyería"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), ofertasxPublicacion("Luxury")));
            AgregarSubasta(new Subasta("Holiday Deals", EnumEstados.ABIERTA, new DateTime(2024, 10, 02, 00, 00, 00), ObtenerArtxCat("Viaje"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), ofertasxPublicacion("Holiday Deals")));
            AgregarSubasta(new Subasta("Black Friday", EnumEstados.ABIERTA, new DateTime(2024, 10, 03, 00, 00, 00), ObtenerArtxCat("Accesorios"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), ofertasxPublicacion("Black Friday")));





        }

    }
}
