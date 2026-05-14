using LogicaNegocio.DTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using LogicaNegocio.InterfacesLogicaAplicacion;
using LogicaNegocio.VO;


namespace LogicaAplicacion.CasosDeUso
{
    public class AltaGasto : ICUAdd<AltaGastoDTO>
    {
        private IRepositorioGasto _repositorioGasto;
        public AltaGasto(IRepositorioGasto repositorioGasto)
        {
            _repositorioGasto = repositorioGasto;
        }
        public void Execute(AltaGastoDTO dto)
        {
            if (dto == null) throw new Exception("El DTO no puede ser null.");
            Gasto g = new Gasto(new VODescripcion(dto.Descripcion),
                                new VOPrecio(dto.Precio),
                                dto.CategoriaId,
                                DateTime.Now);
            _repositorioGasto.Add(g);      
         }
    }
}
