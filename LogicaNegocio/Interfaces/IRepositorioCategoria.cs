using LogicaNegocio;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces
{
    public interface IRepositorioCategoria : IRepositorioAdd<Categoria>, IRepositorioGetAll<Categoria>, IRepositorioGetById<Categoria>, IRepositorioDelete<Categoria>, IRepositorioUpdate<Categoria>
    {
        bool ExisteCategoria(string nombre);
    }
}
