

namespace Dominio.Entidades
{
    public class Cliente : Usuario
    {
        public double Saldo { get; set; }
        public Cliente() { }
        public Cliente(string nombre, string apellido, string email, string contrasenia, double saldo) :
            base(nombre, apellido, email, contrasenia)
        {
            Saldo = saldo;
        }
        public virtual void Validar()
        {
            validateNull();
            validarSaldoNuevo();
        }
        private void validateNull()
        {
            if (string.IsNullOrEmpty(base.Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }

        private void validarSaldoNuevo()
        {
            if(Saldo < 0) {
                throw new Exception("El saldo debe ser mayor a 0");
            }
        }

        public void SumarSaldo(double saldo)
        {
            validarSaldoNuevo();
            Saldo += saldo;
        }

		public override string rol()
		{
			return "Cliente";
		}

		public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"saldo: {Saldo} \n";
            return respuesta;
        }
    }
}
