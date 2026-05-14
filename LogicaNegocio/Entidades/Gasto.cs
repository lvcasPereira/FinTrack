using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Entidades
{
    public class Gasto
    {
        public int Id { get; set; }
        public VODescripcion Descripcion { get; set; }
        public VOPrecio Precio { get; set; }
        public int CategoriaId { get; set; }    
        public Categoria Categoria { get; set; }
        public DateTime Fecha { get; set; }

        public Gasto (VODescripcion descripcion, VOPrecio precio, int CategoriaID, DateTime fecha) {
            Descripcion = descripcion;
            Precio = precio;
            CategoriaId = CategoriaID;
            Fecha = fecha;
        }
        protected Gasto() { }

    }
}
