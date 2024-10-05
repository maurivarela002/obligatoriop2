using Dominio.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.Entidades
{
    public class Articulo : IValidable
    {

        #region Atributos
        public int Id { get; set; }
        public string NombreArt { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioVenta { get; set; }
        private static int _ultimoId;
        #endregion
        #region Constructor
        public Articulo(string nombre, string categoria, int precioVenta)
        {
            Id = _ultimoId++;
            NombreArt = nombre;
            Categoria = categoria;
            PrecioVenta = precioVenta;
        }
        #endregion



        public void Validar()
        {
            //todo:Agregar validaciones de Articulo
        }

        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Id: {_ultimoId++} \n";
            respuesta += $"Nombre articulo: {NombreArt} \n";
            respuesta += $"Categoria: {Categoria} \n";
            respuesta += $"Precio de Venta: {PrecioVenta} \n";
            return respuesta;
        }




    }
}
