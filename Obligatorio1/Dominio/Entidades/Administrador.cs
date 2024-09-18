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
            //todo:Agregar validaciones de Articulo
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            if (Admin) respuesta += $"Soy administrador \n";
            return respuesta;
        }

    }
}
