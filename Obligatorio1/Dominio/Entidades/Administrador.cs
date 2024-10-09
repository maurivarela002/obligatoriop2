
namespace Dominio.Entidades
{
    public class Administrador : Usuario
    {
        public bool Admin { get; }

        public Administrador(string nombre, string apellido, string email, string contrasenia) :
            base(nombre, apellido, email, contrasenia)
        {
            Admin = true;
        }
        public void Validar()
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
            if (Admin) respuesta += $"Administrador \n";
            return respuesta;
        }

    }
}
