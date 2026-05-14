using LogicaNegocio.DTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using LogicaNegocio.InterfacesLogicaAplicacion;
using LogicaNegocio.VO;


namespace LogicaAplicacion.CasosDeUso
{
    public class EliminarGasto : ICUDelete<AltaGastoDTO>
    {
        private IRepositorioGasto _repositorioGasto;
        public EliminarGasto(IRepositorioGasto repositorioGasto)
        {
            _repositorioGasto = repositorioGasto;
        }
        public void Execute(int id)
        {
            if (id == null) throw new Exception("La id no puede ser null.");
            _repositorioGasto.Delete(id);      
         }
    }
}
