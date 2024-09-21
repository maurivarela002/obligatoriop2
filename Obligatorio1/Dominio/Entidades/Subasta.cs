

namespace Dominio.Entidades
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas;

        public Subasta(int id,
                       string nombre,
                       string estado,
                       DateTime fchPublic,
                       List<Articulo> articulos,
                       int idUser,
                       int idPurchUser,
                       DateTime purchDate,
                       List<Oferta> ofertas
                     ) : base(id, nombre, estado, fchPublic, articulos, idUser, idPurchUser, purchDate)
        {
            _ofertas = ofertas;
        }

        public void Validar()
        {
            //todo:Agregar validaciones de Articulo
        }

        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Estado: {Estado} \n";
            respuesta += $"Fecha de Publicacion: {FchPublic} \n";
            //respuesta += $"Lista de Articulos:  \n";
            respuesta += $"Id Usuario: {IdUser} \n";
            respuesta += $"Usuario de Compra: {IdPurchUser} \n";
            respuesta += $"Fecha de Compra: {PurchDate} \n";
            //respuesta += $"Id User: {IdUser} \n";
            return respuesta;
        }

    }
}
