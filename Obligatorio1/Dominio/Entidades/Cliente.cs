using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.Entidades
{
    public class Cliente : Usuario
    {
        public decimal Saldo { get; }

        public Cliente(decimal saldo, string nombre, string apellido, string email, string contrasenia) :
            base(nombre, apellido, email, contrasenia)
        {
            Saldo = saldo;
        }

        public void Validar()
        { 
        
        }

        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Apellido: {Apellido} \n";
            respuesta += $"Email: {Email} \n";
            respuesta += $"Saldo: {Saldo} \n";
            return respuesta;

            return respuesta;
        }
    }
}
