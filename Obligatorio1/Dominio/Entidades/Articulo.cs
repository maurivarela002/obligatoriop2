using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Articulo : IValidable
    {
        #region Atributos
        public int Id { get; set; }
        private static int _ultimoId;
        public string NombreArt { get; set; }
        public string Categoria { get; set; }
        public double PrecioVenta { get; set; }
        #endregion
        #region Constructor
        public Articulo() { }
        public Articulo(string nombre, string categoria, double precioVenta)
        {
            Id = _ultimoId++;
            NombreArt = nombre;
            Categoria = categoria;
            PrecioVenta = precioVenta;
        }
        #endregion
        public void Validar()
        {
            validateNull();
            validarMontoMayorA0();
        }
        private void validateNull()
        {
            if (string.IsNullOrEmpty(NombreArt))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }
        private void validarMontoMayorA0()
        {
            if (PrecioVenta < 0)
            {
                throw new Exception("El precio debe ser mayor a Cero");
            }
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
