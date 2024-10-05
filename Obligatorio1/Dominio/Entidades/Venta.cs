


using static Dominio.Sistema;

namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public bool OfertaR { get; set; }
        public object Articulos { get; private set; }
        public List<Articulo> ObtenerArtxPub { get;set; }

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


        public void Validar()
        {
            //todo:Agregar validaciones de Articulo
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Es Oferta Relampago: {OfertaR} \n";
            return respuesta;
        }


    }
}
