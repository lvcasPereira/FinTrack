using LogicaAplicacion.Mapper;
using LogicaNegocio.DTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using LogicaNegocio.InterfacesLogicaAplicacion;
using LogicaNegocio.VO;


namespace LogicaAplicacion.CasosDeUso
{
    public class EditarGasto : ICUUpdate<AltaGastoDTO>
    {
        private IRepositorioGasto _repositorioGasto;
        public EditarGasto(IRepositorioGasto repositorioGasto)
        {
            _repositorioGasto = repositorioGasto;
        }
        public void Execute(int id, AltaGastoDTO dto)
        {
            if (dto == null) throw new Exception("El DTO no puede ser null.");
            _repositorioGasto.Update(id , GastoMapper.FromDTO(dto));      
         }
    }
}
