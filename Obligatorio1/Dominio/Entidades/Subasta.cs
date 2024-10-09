
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
        public void Validar()
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
        public override string ToString()
        {
            string respuesta = base.ToString();
            return respuesta;
        }
    }
}
