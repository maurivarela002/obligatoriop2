


using static Dominio.Sistema;

namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public bool OfertaR { get; set; }
        public object Articulos { get; private set; }

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
            string respuesta = string.Empty;

            respuesta += $"Id: {++Id} \n";
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Estado: {Estado} \n";
            respuesta += $"Fecha de Publicacion: {FchPublic} \n";
            //respuesta += $"Lista de Articulos: {Articulos} \n";
            respuesta += $"Id Usuario: {IdUser} \n";
            respuesta += $"Usuario de Compra: {IdPurchUser} \n";
            respuesta += $"Fecha de Compra: {PurchDate} \n";
            respuesta += $"Es Oferta Relampago: {OfertaR} \n";
            return respuesta;
        }


    }
}
