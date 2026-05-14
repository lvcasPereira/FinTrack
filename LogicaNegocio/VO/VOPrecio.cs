using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public record VOPrecio
    {
        public int Value {get ; private set;}

        public VOPrecio(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Debe ingresar un monto.");
            }
            Value = value;
        }


    }
}
