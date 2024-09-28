﻿
using Dominio.Interfaces;
using static Dominio.Sistema;

namespace Dominio.Entidades
{
    public abstract class Publicacion : IValidable
    {
        #region Atributos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public DateTime FchPublic { get; set; }
        private List<Articulo> _articulos = new List<Articulo>();
        public int IdUser { get; set; }
        public int IdPurchUser { get; set; }
        public DateTime PurchDate { get; set; }
        public EnumEstados Estados { get; set; }
        private static int _ultimoId;
        #endregion
        #region Constructor
        public Publicacion(int id,
                           string nombre,
                           string estado,
                           DateTime fchPublic,
                           List<Articulo> articulos,
                           int idUser,
                           int idPurchUser,
                           DateTime purchDate,
                           EnumEstados estados)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Estados = estados;
            FchPublic = fchPublic;
            _articulos = articulos;
            IdUser = idUser;
            IdPurchUser = idPurchUser;
            PurchDate = purchDate;
            
        }
        #endregion

        public void Validar()
        {
            //todo:Agregar validaciones de Articulo
        }

        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Estado: {Estado} \n";
            respuesta += $"Fecha de Publicacion: {FchPublic} \n";
            respuesta += $"Lista de Articulos: {_articulos} \n";
            respuesta += $"Id Usuario: {IdUser} \n";
            respuesta += $"Usuario de Compra: {IdPurchUser} \n";
            respuesta += $"Fecha de Compra: {PurchDate} \n";
            respuesta += $"Estados Publicacion: {Estados} \n";
            respuesta += $"Id User: {IdUser} \n";
            return respuesta;
        }



    }
}
