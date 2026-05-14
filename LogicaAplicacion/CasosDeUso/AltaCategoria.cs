using LogicaNegocio.DTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using LogicaNegocio.InterfacesLogicaAplicacion;
using LogicaNegocio.VO;


namespace LogicaAplicacion.CasosDeUso
{
    public class AltaCategoria : ICUAdd<AltaCategoriaDTO>
    {
        private IRepositorioCategoria _repositorioCategoria;
        public AltaCategoria(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }
        public void Execute(AltaCategoriaDTO dto)
        {
            if (dto == null) throw new Exception("El DTO no puede ser null.");
            if (_repositorioCategoria.ExisteCategoria(dto.Nombre));
                Categoria c = new Categoria(new VONombre(dto.Nombre));
            _repositorioCategoria.Add(c);      
         }
    }
}
