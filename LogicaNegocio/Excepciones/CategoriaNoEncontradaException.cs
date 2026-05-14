using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class CategoriaNoEncontradaException : Exception
    {
        public CategoriaNoEncontradaException(string mensaje) : base(mensaje) { }

    }
}
