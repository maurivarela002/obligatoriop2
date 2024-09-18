
namespace Dominio.Entidades
{
    public class Cliente : Usuario
    {
        public decimal Saldo { get; set; }
        public Cliente(string nombre, string apellido, string email, string contrasenia, decimal saldo) :
            base(nombre, apellido, email, contrasenia)

        {
            Saldo = saldo;
        }
        public void Validar()
        {
            //todo:Agregar validaciones de Articulo
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"saldo: {Saldo} \n";
            return respuesta;
        }



    }
}
