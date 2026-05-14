using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class CategoriaDuplicadaException : Exception
    {
        public CategoriaDuplicadaException(string mensaje) : base(mensaje) { }

    }
}
