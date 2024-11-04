
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public abstract class Usuario: IValidable
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
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Apellido: {Apellido} \n";
            respuesta += $"Email: {Email} \n";
            return respuesta;
        }
    }
}
