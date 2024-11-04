


using Dominio.Interfaces;
using static Dominio.Sistema;

namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public bool OfertaR { get; set; }
        public object Articulos { get; private set; }
        public List<Articulo> ObtenerArtxPub { get; set; }
        public Venta(
                     string nombre,
                     EnumEstados estados,
                     DateTime fchPublic,
                     //List<Articulo> articulos,
                     int idUser,
                     int idPurchUser,
                     DateTime purchDate,
                     bool ofertar
            ) : base(nombre, estados, fchPublic, 
                //articulos, 
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
    }
}
