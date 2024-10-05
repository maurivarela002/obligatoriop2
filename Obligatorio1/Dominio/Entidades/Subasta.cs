

using static Dominio.Sistema;

namespace Dominio.Entidades
{
    public class Subasta : Publicacion
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
            //todo:Agregar validaciones de Articulo
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            //respuesta += $"Id User: {IdUser} \n";
            return respuesta;
        }

    }
}
