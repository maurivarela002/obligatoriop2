namespace Dominio.Entidades
{
    public class Cliente
    {

        private static int _ultimoId;

        public string Nombre { get; }

        public Cliente(string nombre)
        {
            Nombre = nombre;
        }

        public void Validar()
        { 
        
        }

        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Nombre: {Nombre}";

            return respuesta;
        }
    }
}
