using LogicaAplicacion.Mapper;
using LogicaNegocio.DTOs;
using LogicaNegocio.Interfaces;
using LogicaNegocio.InterfacesLogicaAplicacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso
{
    public class ListarGasto : ICUGetAll<ListarGastoDTO>
    {
        private IRepositorioGasto _repositorioGasto;
        public ListarGasto(IRepositorioGasto repositorioGasto)
        {
            _repositorioGasto = repositorioGasto;
        }

        public IEnumerable<ListarGastoDTO> Execute()
        {
          return GastoMapper.ToDtoList(_repositorioGasto.GetAll());
        }
    }
}
