using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Oferta : IValidable
    {
        public int Id { get; set; }  
        public int IdUser { get; set; }
        public double Monto { get; set; }
        public DateTime FchOfer { get; set; }
        public string Pnombre { get; set; }
        private static int _ultimoId;

        public Oferta(int id, int idUser, double monto, DateTime fchOfer, string pnombre)
        {
            Id = _ultimoId++;
            IdUser = idUser;
            Monto = monto;
            FchOfer = fchOfer;
            Pnombre = pnombre;
        }

        public void Validar()
        {
            //todo:Agregar validaciones de Articulo
        }
    }
}
