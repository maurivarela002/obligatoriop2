

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
        public void Validar(Cliente cliente)
        {
            validarnull(cliente);
        }

        private bool validarnull(Cliente cliente)
        {
            bool validado = true;
            if (cliente == null) validado = false;
            return validado;
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"saldo: {Saldo} \n";
            return respuesta;
        }



    }
}
