using LogicaAplicacion.Mapper;
using LogicaNegocio.DTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using LogicaNegocio.InterfacesLogicaAplicacion;
using LogicaNegocio.VO;


namespace LogicaAplicacion.CasosDeUso
{
    public class EditarCategoria : ICUUpdate<AltaCategoriaDTO>
    {
        private IRepositorioCategoria _repositorioCategoria;
        public EditarCategoria(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }
        public void Execute(int id, AltaCategoriaDTO dto)
        {
            if (dto == null) throw new Exception("El DTO no puede ser null.");
            _repositorioCategoria.Update(id , CategoriaMapper.FromDTO(dto));      
         }
    }
}
