
using Dominio.Interfaces;
using static Dominio.Sistema;
namespace Dominio.Entidades
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas = new List<Oferta>();
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
        }
        public object Articulos { get; set; }
        public Subasta(
                       string nombre,
                       EnumEstados estados,
                       DateTime fchPublic,
                       int idUser,
                       int idPurchUser,
                       DateTime purchDate
                     //,List<Oferta> ofertas
                     ) : base(nombre, estados, fchPublic,
                         idUser, idPurchUser, purchDate)
        {
            //_ofertas = ofertas;
        }
        public virtual void Validar()
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
        public override string Tipo()
        {
            string salida = "Subasta";
            return salida;
        }

        public override string BtnComprar()
        {
            string salida = "Ofertar";
            return salida;
        }
        public override string ToString()
        {
            string respuesta = base.ToString();
            foreach (var item in _ofertas)
            {
                respuesta += $"{item.User.Nombre}\n";
                respuesta += $"{item.Monto}\n";
            }
            return respuesta;
        }


        public void AgregarOferta(Oferta oferta)
        {
            if (oferta == null)
                throw new Exception("Error en la carga de oferta!");
            oferta.Validar();
            _ofertas.Add(oferta);

        }

        public override double PrecioPublicacion()
        {
            double total = base.PrecioPublicacion();

            if (_ofertas.Count() > 0)
            {
                total = _ofertas[_ofertas.Count() - 1].Monto;
            }
            return total;
        }

        public override string clienteOferente()
        {
            if (_ofertas.Count() == 0)
            {
                return null;
             }
            return _ofertas[_ofertas.Count() - 1].User.Email;
        }

    }

}