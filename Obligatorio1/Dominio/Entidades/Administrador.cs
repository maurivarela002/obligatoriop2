
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
        public void Validar(Administrador administrador)
        {
            validarnull(administrador);
        }

        private bool validarnull(Administrador administrador)
        {
            bool validado = true;
            if (administrador == null) validado = false;
            return validado;
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            if (Admin) respuesta += $"Soy administrador \n";
            return respuesta;
        }

    }
}
