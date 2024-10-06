
using Dominio.Interfaces;
using static Dominio.Sistema;
namespace Dominio.Entidades
{
    public class Subasta : Publicacion, IValidable
    {
        private List<Oferta> _ofertas;
        public object Articulos { get; private set; }

        public Subasta(
                       string nombre,
                       EnumEstados estados,
                       DateTime fchPublic,
                       List<Articulo> articulos,
                       int idUser,
                       int idPurchUser,
                       DateTime purchDate,
                       List<Oferta> ofertas
                     ) : base(nombre, estados, fchPublic, articulos, idUser, idPurchUser, purchDate)
        {
            _ofertas = ofertas;
        }

        public void Validar(object? paramOpcional)
        {
            validarnull((Subasta)paramOpcional);
        }

        private bool validarnull(Subasta subasta)
        {
            bool validado = true;
            if (subasta == null) validado = false;
            return validado;
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            return respuesta;
        }

    }
}
