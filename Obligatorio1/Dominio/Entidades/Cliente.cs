

namespace Dominio.Entidades
{
    public class Cliente : Usuario
    {
        public double Saldo { get; set; }
        public Cliente(string nombre, string apellido, string email, string contrasenia, double saldo) :
            base(nombre, apellido, email, contrasenia)
        {
            Saldo = saldo;
        }
        public virtual void Validar()
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
            respuesta += $"saldo: {Saldo} \n";
            return respuesta;
        }
    }
}
