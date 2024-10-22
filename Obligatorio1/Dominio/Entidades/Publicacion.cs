
using Dominio.Interfaces;
using static Dominio.Sistema;

namespace Dominio.Entidades
{
    public abstract class Publicacion: IValidable
    {
        #region Atributos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public EnumEstados Estados { get; set; }
        public DateTime FchPublic { get; set; }
        private List<Articulo> _articulos = new List<Articulo>();
        public int IdUser { get; set; }
        public int IdPurchUser { get; set; }
        public DateTime PurchDate { get; set; }
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

        public void Validar()
        {
            validateNull();
        }
        private void validateNull()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }

        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre de la publicacion: {Nombre} \n";
            respuesta += $"Estados Publicacion: {Estados} \n";
            respuesta += $"Fecha de Publicacion: {FchPublic:dd/MM/yyyy} \n";
            return respuesta;
        }
    }
}
