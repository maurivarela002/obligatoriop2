﻿using Dominio.Entidades;
using System.Drawing;
namespace Dominio
{
    public class Sistema
    {
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Oferta> _ofertas = new List<Oferta>();

        public Sistema()
        {
            PrecargarDatos();

        }
        public enum EnumEstados
        {
            ABIERTA,
            CERRADA,
            CANCELADA
        }
        public List<Articulo> Articulos
        {
            get { return _articulos; }
        }

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
        }
        public List<Publicacion> Publicaciones
        {
            get { return _publicaciones; }
        }
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
        }
        public void AgregarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new Exception("Error en la carga de Usuario!");
            usuario.Validar();
            _usuarios.Add(usuario);
        }
        public List<Cliente> obtenerClientes()
        {
            List<Cliente> aux = new List<Cliente>();

            foreach (Usuario user in _usuarios)
            {
                if (user is Cliente)
                {
                    Cliente cliente = (Cliente)user;
                    aux.Add(cliente);
                }
            }
            return aux;
        }

        public List<Administrador> obtenerAdministradores()
        {
            List<Administrador> aux = new List<Administrador>();

            foreach (Usuario user in _usuarios)
            {
                if (user is Administrador)
                {
                    Administrador admin = (Administrador)user;
                    aux.Add(admin);
                }
            }
            return aux;
        }

        public void AgregarPublicacion(Publicacion publicacion)
        {
            if (publicacion == null) throw new Exception("Error en la carga de publicacion!");
            publicacion.Validar();
            _publicaciones.Add(publicacion);
        }
        public List<Venta> obtenerVentas()
        {
            List<Venta> aux = new List<Venta>();

            foreach (Publicacion publis in _publicaciones)
            {
                if (publis is Venta)
                {
                    Venta venta = (Venta)publis;
                    aux.Add(venta);
                }
            }
            return aux;
        }
        public List<Subasta> obtenerSubastas()
        {
            List<Subasta> aux = new List<Subasta>();

            foreach (Publicacion publis in _publicaciones)
            {
                if (publis is Subasta)
                {
                    Subasta subasta = (Subasta)publis;
                    aux.Add(subasta);
                }
            }
            return aux;
        }

        public void AgregarArticulo(Articulo articulo)
        {
            if (articulo == null) throw new Exception("Error en la carga de Articulo!");
            articulo.Validar();
            _articulos.Add(articulo);
        }
        public void AgregarOferta(Oferta oferta)
        {
            if (oferta == null) throw new Exception("Error en la carga de oferta!");
            oferta.Validar();
            _ofertas.Add(oferta);
        }
        public List<Articulo> ObtenerArtxCat(string pCategoria)
        {
            List<Articulo> aux = new List<Articulo>();

            foreach (Articulo unArticulo in _articulos)
            {
                if (unArticulo.Categoria.ToLower() == pCategoria.ToLower())
                {
                    aux.Add(unArticulo);
                }
            }
            return aux;
        }
        public List<Articulo> ArticulosxNombrePublicacion(string pNombre)
        {
            List<Articulo> aux = new List<Articulo>();
            switch (pNombre.ToLower())
            {
                case "electro party":
                    return ObtenerArtxCat("Electrónica");
                case "sport sale":
                    return ObtenerArtxCat("Deportes");
                case "mega sale":
                    return ObtenerArtxCat("Ropa");
                case "tech expo":
                    return ObtenerArtxCat("Periféricos");
                case "gadget fest":
                    return ObtenerArtxCat("Audio");
                case "book sales":
                    return ObtenerArtxCat("Libros");
                case "work world":
                    return ObtenerArtxCat("Oficina");
                case "mayor tranquilidad":
                    return ObtenerArtxCat("Seguridad");
                case "luxury":
                    return ObtenerArtxCat("Joyería");
                case "holiday deals":
                    return ObtenerArtxCat("Viaje");
                case "black friday":
                    return ObtenerArtxCat("Accesorios");
                default:
                    return aux;
            }

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
            #region clientes
            //Precarga de  10 clientes
            AgregarUsuario(new Cliente("Mauricio", "Varela", "mauri.sape@mail.com", "password1", 1000));
            AgregarUsuario(new Cliente("Matias", "Alvarez", "mati.programer@mail.com", "password2", 1500));
            AgregarUsuario(new Cliente("Carlos", "Lopez", "carlos.lopez@mail.com", "password3", 2000));
            AgregarUsuario(new Cliente("María", "García", "maria.garcia@mail.com", "password1", 1500));
            AgregarUsuario(new Cliente("Juan", "Pérez", "juan.perez@mail.com", "password2", 1000));
            AgregarUsuario(new Cliente("Ana", "Sánchez", "ana.sanchez@mail.com", "password4", 2500));
            AgregarUsuario(new Cliente("Pedro", "Martínez", "pedro.martinez@mail.com", "password5", 3000));
            AgregarUsuario(new Cliente("Luis", "Gómez", "luis.gomez@mail.com", "password6", 1200));
            AgregarUsuario(new Cliente("Laura", "Fernández", "laura.fernandez@mail.com", "password7", 1800));
            AgregarUsuario(new Cliente("Jorge", "Díaz", "jorge.diaz@mail.com", "password8", 2200));
            //AgregarUsuario(null); prueba de precarga nula
            #endregion

            #region admin
            //Precarga de 2 Administradores
            //AgregarAdministrador(null); //prueba de precarga nula 
            AgregarUsuario(new Administrador("Marta", "Suarez", "marta.suarez@mail.com", "admin1"));
            AgregarUsuario(new Administrador("Luis", "Ramirez", "luis.ramirez@mail.com", "admin2"));
            #endregion

            #region Articulos
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
            //AgregarArticulo(null); //prueba de precarga nula
            #endregion

            #region Ventas
            //************Precarga Publicaciones ****************
            //Precarga 10 ventas 
            AgregarPublicacion(new Venta("Electro Party", EnumEstados.ABIERTA, new DateTime(2024, 10, 05, 00, 00, 00), ObtenerArtxCat("Electrónica"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), false));
            AgregarPublicacion(new Venta("Sport Sale", EnumEstados.ABIERTA, new DateTime(2024, 10, 05, 00, 00, 00), ObtenerArtxCat("Deportes"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), true));
            AgregarPublicacion(new Venta("Mega Sale", EnumEstados.ABIERTA, new DateTime(2024, 10, 06, 00, 00, 00), ObtenerArtxCat("Ropa"), 0, 0, new DateTime(2024, 10, 06, 00, 00, 00), false));
            AgregarPublicacion(new Venta("Tech Expo", EnumEstados.ABIERTA, new DateTime(2024, 10, 07, 00, 00, 00), ObtenerArtxCat("Periféricos"), 0, 0, new DateTime(2024, 10, 07, 00, 00, 00), true));
            AgregarPublicacion(new Venta("Gadget Fest", EnumEstados.ABIERTA, new DateTime(2024, 10, 08, 00, 00, 00), ObtenerArtxCat("Audio"), 0, 0, new DateTime(2024, 10, 08, 00, 00, 00), false));
            AgregarPublicacion(new Venta("Book Sales", EnumEstados.ABIERTA, new DateTime(2024, 10, 09, 00, 00, 00), ObtenerArtxCat("Libros"), 0, 0, new DateTime(2024, 10, 09, 00, 00, 00), true));
            AgregarPublicacion(new Venta("Work World", EnumEstados.ABIERTA, new DateTime(2024, 10, 10, 00, 00, 00), ObtenerArtxCat("Oficina"), 0, 0, new DateTime(2024, 10, 10, 00, 00, 00), false));
            AgregarPublicacion(new Venta("Mayor Tranquilidad", EnumEstados.ABIERTA, new DateTime(2024, 10, 11, 00, 00, 00), ObtenerArtxCat("Seguridad"), 0, 0, new DateTime(2024, 10, 11, 00, 00, 00), true));
            AgregarPublicacion(new Venta("Luxury", EnumEstados.ABIERTA, new DateTime(2024, 10, 12, 00, 00, 00), ObtenerArtxCat("Joyería"), 0, 0, new DateTime(2024, 10, 12, 00, 00, 00), false));
            AgregarPublicacion(new Venta("Holiday Deals", EnumEstados.ABIERTA, new DateTime(2024, 10, 13, 00, 00, 00), ObtenerArtxCat("Viaje"), 0, 0, new DateTime(2024, 10, 13, 00, 00, 00), true));
            AgregarPublicacion(new Venta("Black Friday", EnumEstados.ABIERTA, new DateTime(2024, 10, 14, 00, 00, 00), ObtenerArtxCat("Accesorios"), 0, 0, new DateTime(2024, 10, 14, 00, 00, 00), true));
            #endregion

            #region Ofertas
            //Precargas de Ofertas
            AgregarOferta(new Oferta(0, 0, 150.20, new DateTime(2024, 10, 05, 00, 00, 00), "Luxury"));
            AgregarOferta(new Oferta(2, 2, 120.10, new DateTime(2024, 10, 04, 00, 00, 00), "Black Friday"));
            #endregion

            #region Subastas
            //Precarga 10 subastas
            AgregarPublicacion(new Subasta("Luxury", EnumEstados.ABIERTA, new DateTime(2024, 10, 01, 00, 00, 00), ObtenerArtxCat("Joyería"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), ofertasxPublicacion("Luxury")));
            AgregarPublicacion(new Subasta("Holiday Deals", EnumEstados.ABIERTA, new DateTime(2024, 10, 02, 00, 00, 00), ObtenerArtxCat("Viaje"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), ofertasxPublicacion("sin ofertas")));
            AgregarPublicacion(new Subasta("Black Friday", EnumEstados.ABIERTA, new DateTime(2024, 10, 03, 00, 00, 00), ObtenerArtxCat("Accesorios"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), ofertasxPublicacion("Black Friday")));
            AgregarPublicacion(new Subasta("Black Friday", EnumEstados.ABIERTA, new DateTime(2024, 10, 03, 00, 00, 00), ObtenerArtxCat("Accesorios"), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), ofertasxPublicacion("sin ofertas")));
            AgregarPublicacion(new Subasta("Cyber Monday", EnumEstados.ABIERTA, new DateTime(2024, 11, 27, 00, 00, 00), ObtenerArtxCat("Periféricos"), 0, 0, new DateTime(2024, 11, 30, 00, 00, 00), ofertasxPublicacion("sin ofertas")));
            AgregarPublicacion(new Subasta("Navidad 2024", EnumEstados.ABIERTA, new DateTime(2024, 12, 20, 00, 00, 00), ObtenerArtxCat("Papelería"), 0, 0, new DateTime(2024, 12, 25, 00, 00, 00), ofertasxPublicacion("sin ofertas")));
            AgregarPublicacion(new Subasta("Año Nuevo 2025", EnumEstados.ABIERTA, new DateTime(2024, 12, 31, 00, 00, 00), ObtenerArtxCat("Muebles"), 0, 0, new DateTime(2025, 01, 01, 00, 00, 00), ofertasxPublicacion("sin ofertas")));
            AgregarPublicacion(new Subasta("Verano 2025", EnumEstados.ABIERTA, new DateTime(2025, 01, 15, 00, 00, 00), ObtenerArtxCat("Ropa"), 0, 0, new DateTime(2025, 02, 15, 00, 00, 00), ofertasxPublicacion("sin ofertas")));
            AgregarPublicacion(new Subasta("Primavera 2025", EnumEstados.ABIERTA, new DateTime(2025, 03, 20, 00, 00, 00), ObtenerArtxCat("Ropa"), 0, 0, new DateTime(2025, 04, 10, 00, 00, 00), ofertasxPublicacion("sin ofertas")));
            AgregarPublicacion(new Subasta("San Valentín 2025", EnumEstados.ABIERTA, new DateTime(2025, 02, 10, 00, 00, 00), ObtenerArtxCat("Joyería"), 0, 0, new DateTime(2025, 02, 14, 00, 00, 00), ofertasxPublicacion("sin ofertas")));
            #endregion

        }
    }
}
