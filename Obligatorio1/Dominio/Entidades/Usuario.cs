using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public abstract class Usuario : IValidable
    {
        private static int _ultimoId;
        public int Id { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Email { get; }
        public string Contrasenia { get; }
        public Usuario() { }
        public Usuario(string nombre, string apellido, string email, string contrasenia)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasenia = contrasenia;
        }
        public void Validar()
        {
            validateNull();
            validarAlfaNumerico();
            validarSaldoNuevo();
        }
        private void validateNull()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }

        private bool EsLetras(char c)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
            return true;
        }

        private bool EsNumeros(char c)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
            return true;
        }

        private void validarAlfaNumerico()
        {
            bool letra = false;
            bool numero = false;
            bool salida = false;
            foreach (char c in Contrasenia)
            {
                if (EsNumeros(c))
                {
                    numero = true;
                }
                if (EsLetras(c))
                {
                    letra = true;
                }
            }
            salida = numero && letra;
            if (!salida)
            {
                throw new Exception("La contraseña debe ser alfanumerica.");
            }
        }
        public abstract void validarSaldoNuevo();

        public abstract string rol();
        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Apellido: {Apellido} \n";
            respuesta += $"Email: {Email} \n";
            return respuesta;
        }
    }
}
