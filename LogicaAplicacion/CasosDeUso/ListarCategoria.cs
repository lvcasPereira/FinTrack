using LogicaAplicacion.Mapper;
using LogicaNegocio.DTOs;
using LogicaNegocio.Interfaces;
using LogicaNegocio.InterfacesLogicaAplicacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso
{
    public class ListarCategoria : ICUGetAll<ListarCategoriaDTO>
    {
        private IRepositorioCategoria _repositorioCategoria;
        public ListarCategoria(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public IEnumerable<ListarCategoriaDTO> Execute()
        {
          return CategoriaMapper.ToDtoList(_repositorioCategoria.GetAll());
        }
    }
}
