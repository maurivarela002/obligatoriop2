using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Oferta
    {
        public int Id { get; set; }  
        public int IdUser { get; set; }
        public decimal Monto { get; set; }
        public DateTime FchOfer { get; set; }
        public string Pnombre { get; set; }
        private static int _ultimoId;

        public Oferta(int id, int idUser, decimal monto, DateTime fchOfer, string pnombre)
        {
            Id = _ultimoId++;
            IdUser = idUser;
            Monto = monto;
            FchOfer = fchOfer;
            Pnombre = pnombre;
        }
    }
}
