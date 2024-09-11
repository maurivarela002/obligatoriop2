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


        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Apellido: {Apellido} \n";
            respuesta += $"Email: {Email} \n";
            if(Admin)respuesta += $"Soy administrador";
            return respuesta;
        }
    }
}
