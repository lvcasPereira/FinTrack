using LogicaNegocio;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces
{
    public interface IRepositorioGasto : IRepositorioAdd<Gasto>, IRepositorioGetAll<Gasto>, IRepositorioGetById<Gasto>, IRepositorioDelete<Gasto>, IRepositorioUpdate<Gasto>
    {
        IEnumerable<Gasto> GetByCategoria(int categoriaId); 
        IEnumerable<Gasto> GetByFecha(DateTime fecha);
    }
}
