


using Dominio.Interfaces;
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
                     List<Articulo> articulos,
                     int idUser,
                     int idPurchUser,
                     DateTime purchDate,
                     bool ofertar
            ) : base(nombre, estados, fchPublic, articulos, idUser, idPurchUser, purchDate)
        {
            OfertaR = ofertar;

        }


        public void Validar(object? paramOpcional)
        {
            validarnull((Venta)paramOpcional);
        }

        private bool validarnull(Venta venta)
        {
            bool validado = true;
            if (venta == null) validado = false;
            return validado;
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
