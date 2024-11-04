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
        public Oferta() { }
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
            validateNull();
        }
        private void validateNull()
        {
            if (string.IsNullOrEmpty(Pnombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }

		public override string ToString()
		{
			string respuesta = string.Empty;
			respuesta += $"Nombre de Publicacion: {Pnombre} \n";
			respuesta += $"Id User: {IdUser} \n";
			respuesta += $"Importe: {Monto} \n";
			respuesta += $"Fecha de Oferta: {FchOfer} \n";
			return respuesta;
		}



	}
}
