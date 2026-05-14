using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public record VONombre
    {
        public string Value {get ; private set;}

        public VONombre(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El nombre de la categoria no puede ser vacio.");
            }
            Value = value;
        }


    }
}
