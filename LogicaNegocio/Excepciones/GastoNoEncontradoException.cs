using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class GastoNoEncontradoException : Exception
    {
        public GastoNoEncontradoException(string mensaje) : base(mensaje) { }

    }
}
