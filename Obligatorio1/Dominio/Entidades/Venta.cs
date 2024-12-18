﻿using Dominio.Interfaces;
using static Dominio.Sistema;

namespace Dominio.Entidades
{
	public class Venta : Publicacion, IValidable
	{
		public bool OfertaR { get; set; }
		public object Articulos { get; private set; }
		public List<Articulo> ObtenerArtxPub { get; set; }
		public Venta(
					 string nombre,
					 EnumEstados estados,
					 DateTime fchPublic,
					 int idUser,
					 int idPurchUser,
					 DateTime purchDate,
					 bool ofertar
			) : base(nombre, estados, fchPublic, 
				idUser, idPurchUser, purchDate)
		{
			OfertaR = ofertar;

		}
		public virtual void Validar()
		{
			validateNull();
		}
		private void validateNull()
		{
			if (string.IsNullOrEmpty(base.Nombre))
			{
				throw new Exception("El nombre no puede ser vacio");
			}
		}

		public override string Tipo()
		{
			string salida = "Venta";
			return salida;
		}

		public override string BtnComprar()
		{
			string salida = "Comprar";
			return salida;
		}
		public override string ToString()
		{
			string respuesta = base.ToString();
			if (OfertaR)
			{
				respuesta += $"Oferta Relampago \n";
			}
			return respuesta;
		}

		public override double PrecioPublicacion()
		{
			double total = base.PrecioPublicacion();

			if (OfertaR) 
			{
				total = Math.Round(total * 0.8);
			}
			return total;
		}

        public override string clienteOferente()
        {
			return null;
        }
    }
}
