
namespace Dominio.Entidades
{
    public abstract class Usuario
    {
        private static int _ultimoId;

        public int Id { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Email { get; }
        public string Contrasenia { get; }
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
            //todo:Agregar validaciones de Articulo
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
