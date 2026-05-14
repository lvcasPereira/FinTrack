using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public VONombre Nombre { get; set; }

        public Categoria(VONombre nombre) {
        
            Nombre = nombre;   
        }

        protected Categoria() { }

    }
}
