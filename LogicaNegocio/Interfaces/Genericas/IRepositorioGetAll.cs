using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces
{
    public interface IRepositorioGetAll<T>
    {
         IEnumerable<T> GetAll();
    }
}
