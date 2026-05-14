using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public record VODescripcion
    {
        public string Value {get ; private set;}

        public VODescripcion(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("La descripción no puede ser nula o vacía.");
            }
            Value = value;
        }


    }
}
