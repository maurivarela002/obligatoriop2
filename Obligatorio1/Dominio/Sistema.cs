using Dominio.Entidades;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
namespace Dominio
{
	public class Sistema
	{
		private List<Articulo> _articulos = new List<Articulo>();
		private List<Usuario> _usuarios = new List<Usuario>();
		private List<Publicacion> _publicaciones = new List<Publicacion>();
		private List<Oferta> _ofertas = new List<Oferta>();

		private static Sistema instancia;
		public static Sistema Instancia
		{
			get
			{
				if (instancia == null) instancia = new Sistema();
				return instancia;
			}
		}
		public Sistema()
		{
			PrecargarDatos();
			PrecargarArticulos();
			PrecargarOfertas();


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
        public bool ClienteExiste(string email, string password)
        {
            Boolean usuarioValido = false;
            foreach (Cliente unCliente in obtenerClientes())
            {
                if (unCliente.Email == email.ToLower() && unCliente.Contrasenia == password.ToLower())
                {
                    usuarioValido = true;
                }
            }
            return usuarioValido;
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


		public void AgregarArticulo(Articulo articulo)
		{
			if (articulo == null) throw new Exception("Error en la carga de Articulo!");
			articulo.Validar();
			_articulos.Add(articulo);
		}
		public void AgregarOferta(Oferta oferta)
		{
			if (oferta == null)
				throw new Exception("Error en la carga de oferta!");
			oferta.Validar();
			_ofertas.Add(oferta);
		}
		//public List<Articulo> ObtenerArtxCat(string pCategoria)
		//{
		//    List<Articulo> aux = new List<Articulo>();

		//    foreach (Articulo unArticulo in _articulos)
		//    {
		//        if (unArticulo.Categoria.ToLower() == pCategoria.ToLower())
		//        {
		//            aux.Add(unArticulo);
		//        }
		//    }
		//    return aux;
		//}

		public List<Articulo> ObtenerArticulosRandom(int cantidad)
		{
			List<Articulo> aux = new List<Articulo>();
			Random rand = new Random();
			int totalArticulos = _articulos.Count;

			if (cantidad > totalArticulos)
			{
				cantidad = totalArticulos;
			}

			List<int> indicesSeleccionados = new List<int>();


			while (aux.Count <= cantidad)
			{
				int index = rand.Next(totalArticulos);
				if (!indicesSeleccionados.Contains(index))
				{
					aux.Add(_articulos[index]);
					indicesSeleccionados.Add(index);
				}
			}

			return aux;
		}

		public Publicacion obtenerPublicacion(string NombrePublicacion)
		{
			foreach (var item in _publicaciones)
			{
				if (item.Nombre.ToLower() != null && item.Nombre.ToLower() == NombrePublicacion.ToLower())
				{
					return item;
				}
			}
			return null;

		}

		public List<Articulo> ArticulosxNombrePublicacion(string nombrePublicacion)
		{
			List<Articulo> aux = new List<Articulo>();
			foreach (var item in _publicaciones)
			{
				if (item.Nombre.ToLower() == nombrePublicacion.ToLower())
				{
					foreach (var art in _articulos)
					{
						aux.Add(art);
					}
				}
			}
			return aux;

		}

		public List<Oferta> OfertasxNombrePublicacion(string nombrePublicacion)
		{
			List<Oferta> aux = new List<Oferta>();
			foreach (Publicacion item in _publicaciones)
			{
				foreach (Oferta ofe in _ofertas)
				{
					if (nombrePublicacion != null && item.Nombre == nombrePublicacion)
					{
						aux.Add(ofe);
					}
				}
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
			AgregarPublicacion(new Venta("Electro Party", EnumEstados.ABIERTA, new DateTime(2024, 10, 05, 00, 00, 00), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), false));
			AgregarPublicacion(new Venta("Sport Sale", EnumEstados.ABIERTA, new DateTime(2024, 10, 05, 00, 00, 00), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00), true));
			AgregarPublicacion(new Venta("Mega Sale", EnumEstados.ABIERTA, new DateTime(2024, 10, 06, 00, 00, 00), 0, 0, new DateTime(2024, 10, 06, 00, 00, 00), false));
			AgregarPublicacion(new Venta("Tech Expo", EnumEstados.ABIERTA, new DateTime(2024, 10, 07, 00, 00, 00), 0, 0, new DateTime(2024, 10, 07, 00, 00, 00), true));
			AgregarPublicacion(new Venta("Gadget Fest", EnumEstados.ABIERTA, new DateTime(2024, 10, 08, 00, 00, 00), 0, 0, new DateTime(2024, 10, 08, 00, 00, 00), false));
			AgregarPublicacion(new Venta("Book Sales", EnumEstados.ABIERTA, new DateTime(2024, 10, 09, 00, 00, 00), 0, 0, new DateTime(2024, 10, 09, 00, 00, 00), true));
			AgregarPublicacion(new Venta("Work World", EnumEstados.ABIERTA, new DateTime(2024, 10, 10, 00, 00, 00), 0, 0, new DateTime(2024, 10, 10, 00, 00, 00), false));
			AgregarPublicacion(new Venta("Mayor Tranquilidad", EnumEstados.ABIERTA, new DateTime(2024, 10, 11, 00, 00, 00), 0, 0, new DateTime(2024, 10, 11, 00, 00, 00), true));
			AgregarPublicacion(new Venta("Big Sale", EnumEstados.ABIERTA, new DateTime(2024, 10, 12, 00, 00, 00), 0, 0, new DateTime(2024, 10, 12, 00, 00, 00), false));
			AgregarPublicacion(new Venta("Dia del Hogar", EnumEstados.ABIERTA, new DateTime(2024, 10, 13, 00, 00, 00), 0, 0, new DateTime(2024, 10, 13, 00, 00, 00), true));
			AgregarPublicacion(new Venta("PlayGround", EnumEstados.ABIERTA, new DateTime(2024, 10, 14, 00, 00, 00), 0, 0, new DateTime(2024, 10, 14, 00, 00, 00), true));
			#endregion

			#region Ofertas
			//Precargas de Ofertas
			AgregarOferta(new Oferta(0, 0, 150.20, new DateTime(2024, 10, 05, 00, 00, 00), "Luxury"));
			AgregarOferta(new Oferta(2, 2, 120.10, new DateTime(2024, 10, 04, 00, 00, 00), "Black Friday"));
			#endregion

			#region Subastas
			//Precarga 10 subastas
			AgregarPublicacion(new Subasta("Luxury", EnumEstados.ABIERTA, new DateTime(2024, 10, 01, 00, 00, 00), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00)));
			AgregarPublicacion(new Subasta("Holiday Deals", EnumEstados.ABIERTA, new DateTime(2024, 10, 02, 00, 00, 00), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00)));
			AgregarPublicacion(new Subasta("Black Friday", EnumEstados.ABIERTA, new DateTime(2024, 10, 03, 00, 00, 00), 0, 0, new DateTime(2024, 10, 05, 00, 00, 00)));
			AgregarPublicacion(new Subasta("Black Friday", EnumEstados.ABIERTA, new DateTime(2024, 10, 03, 00, 00, 00), 0, 0, new DateTime(2024, 10, 08, 00, 00, 00)));
			AgregarPublicacion(new Subasta("Cyber Monday", EnumEstados.ABIERTA, new DateTime(2024, 11, 27, 00, 00, 00), 0, 0, new DateTime(2024, 11, 30, 00, 00, 00)));
			AgregarPublicacion(new Subasta("Navidad 2024", EnumEstados.ABIERTA, new DateTime(2024, 12, 20, 00, 00, 00), 0, 0, new DateTime(2024, 12, 25, 00, 00, 00)));
			AgregarPublicacion(new Subasta("Año Nuevo 2025", EnumEstados.ABIERTA, new DateTime(2024, 12, 31, 00, 00, 00), 0, 0, new DateTime(2025, 01, 01, 00, 00, 00)));
			AgregarPublicacion(new Subasta("Verano 2025", EnumEstados.ABIERTA, new DateTime(2025, 01, 15, 00, 00, 00), 0, 0, new DateTime(2025, 02, 15, 00, 00, 00)));
			AgregarPublicacion(new Subasta("Primavera 2025", EnumEstados.ABIERTA, new DateTime(2025, 03, 20, 00, 00, 00), 0, 0, new DateTime(2025, 04, 10, 00, 00, 00)));
			AgregarPublicacion(new Subasta("San Valentín 2025", EnumEstados.ABIERTA, new DateTime(2025, 02, 10, 00, 00, 00), 0, 0, new DateTime(2025, 02, 14, 00, 00, 00)));
			#endregion
			_publicaciones.Sort();
		}

		private void PrecargarArticulos()
		{

			Publicacion p1 = obtenerPublicacion("Electro Party");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p1.AgregarArticulo(item);
			}

			Publicacion p2 = obtenerPublicacion("Sport Sale");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p2.AgregarArticulo(item);
			}

			Publicacion p3 = obtenerPublicacion("Mega Sale");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p3.AgregarArticulo(item);
			}

			Publicacion p4 = obtenerPublicacion("Tech Expo");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p4.AgregarArticulo(item);
			}

			Publicacion p5 = obtenerPublicacion("Gadget Fest");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p5.AgregarArticulo(item);
			}

			Publicacion p6 = obtenerPublicacion("Book Sales");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p6.AgregarArticulo(item);
			}

			Publicacion p7 = obtenerPublicacion("Work World");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p7.AgregarArticulo(item);
			}

			Publicacion p8 = obtenerPublicacion("Mayor Tranquilidad");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p8.AgregarArticulo(item);
			}

			Publicacion p9 = obtenerPublicacion("Luxury");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p9.AgregarArticulo(item);
			}

			Publicacion p10 = obtenerPublicacion("Holiday Deals");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p10.AgregarArticulo(item);
			}

			Publicacion p11 = obtenerPublicacion("Black Friday");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p11.AgregarArticulo(item);
			}

			Publicacion p12 = obtenerPublicacion("Cyber Monday");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p12.AgregarArticulo(item);
			}

			Publicacion p13 = obtenerPublicacion("Navidad 2024");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p12.AgregarArticulo(item);
			}

			Publicacion p14 = obtenerPublicacion("Año Nuevo 2025");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p14.AgregarArticulo(item);
			}

			Publicacion p15 = obtenerPublicacion("Verano 2025");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p15.AgregarArticulo(item);
			}

			Publicacion p16 = obtenerPublicacion("Primavera 2025");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p16.AgregarArticulo(item);
			}

			Publicacion p17 = obtenerPublicacion("San Valentín 2025");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p17.AgregarArticulo(item);
			}

			Publicacion p18 = obtenerPublicacion("Big Sale");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p18.AgregarArticulo(item);
			}

			Publicacion p19 = obtenerPublicacion("Dia del Hogar");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p19.AgregarArticulo(item);
			}

			Publicacion p20 = obtenerPublicacion("PlayGround");
			foreach (Articulo item in ObtenerArticulosRandom(5))
			{
				p20.AgregarArticulo(item);
			}
		}

		private void PrecargarOfertas()
		{
			Publicacion o1 = obtenerPublicacion("Electro Party");
			if (o1.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o1;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Electro Party")
						subasta.AgregarOferta(unaoferta);
				}
			}

			Publicacion o2 = obtenerPublicacion("Luxury");
			if (o2.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o2;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Luxury")
						subasta.AgregarOferta(unaoferta);
				}
			}

			Publicacion o3 = obtenerPublicacion("Holiday Deals");
			if (o3.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o3;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Holiday Deals")
						subasta.AgregarOferta(unaoferta);
				}
			}
			Publicacion o4 = obtenerPublicacion("Black Friday");
			if (o4.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o4;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Black Friday")
						subasta.AgregarOferta(unaoferta);
				}
			}

			Publicacion o5 = obtenerPublicacion("Cyber Monday");
			if (o5.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o5;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Cyber Monday")
						subasta.AgregarOferta(unaoferta);
				}
			}

			Publicacion o6 = obtenerPublicacion("Navidad 2024");
			if (o6.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o6;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Navidad 2024")
						subasta.AgregarOferta(unaoferta);
				}
			}

			Publicacion o7 = obtenerPublicacion("Año Nuevo 2025");
			if (o7.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o7;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Año Nuevo 2025")
						subasta.AgregarOferta(unaoferta);
				}
			}

			Publicacion o8 = obtenerPublicacion("Verano 2025");
			if (o8.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o8;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Verano 2025")
						subasta.AgregarOferta(unaoferta);
				}
			}

			Publicacion o9 = obtenerPublicacion("Primavera 2025");
			if (o9.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o9;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "Primavera 2025")
						subasta.AgregarOferta(unaoferta);
				}
			}

			Publicacion o10 = obtenerPublicacion("San Valentín 2025");
			if (o10.Tipo() == "Subasta")
			{
				Subasta subasta = (Subasta)o10;
				foreach (Oferta unaoferta in _ofertas)
				{
					if (unaoferta.Pnombre == "San Valentín 2025")
						subasta.AgregarOferta(unaoferta);
				}
			}

		}

	}
}
