
using Dominio.Interfaces;
using static Dominio.Sistema;

namespace Dominio.Entidades
{
    public abstract class Publicacion
    {
        #region Atributos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FchPublic { get; set; }
        public List<Articulo> ObtenerArtxPub { get; set; }
        private List<Articulo> _articulos = new List<Articulo>();
        public int IdUser { get; set; }
        public int IdPurchUser { get; set; }
        public DateTime PurchDate { get; set; }
        public EnumEstados Estados { get; set; }
        private static int _ultimoId;
        #endregion
        #region Constructor
        public Publicacion(
                           string nombre,
                           EnumEstados estados,
                           DateTime fchPublic,
                           List<Articulo> articulos,
                           int idUser,
                           int idPurchUser,
                           DateTime purchDate
                           )
        {
            Id = _ultimoId++;
            Nombre = nombre;
            FchPublic = fchPublic;
            _articulos = articulos;
            IdUser = idUser;
            IdPurchUser = idPurchUser;
            PurchDate = purchDate;

        }
        #endregion


        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre de la publicacion: {Nombre} \n";
            respuesta += $"Fecha de Publicacion: {FchPublic:dd/MM/yyyy} \n";
            respuesta += $"Id Usuario: {IdUser} \n";
            respuesta += $"Usuario de Compra: {IdPurchUser} \n";
            respuesta += $"Fecha de Compra: {PurchDate:dd/MM/yyyy} \n";
            respuesta += $"Estados Publicacion: {Estados} \n";
            respuesta += $"Id User: {IdUser} \n";
            return respuesta;
        }



    }
}
