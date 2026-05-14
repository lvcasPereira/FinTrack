using LogicaNegocio.DTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using LogicaNegocio.InterfacesLogicaAplicacion;
using LogicaNegocio.VO;


namespace LogicaAplicacion.CasosDeUso
{
    public class EliminarCategoria : ICUDelete<AltaCategoriaDTO>
    {
        private IRepositorioCategoria _repositorioCategoria;
        public EliminarCategoria(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }
        public void Execute(int id)
        {
            if (id == null) throw new Exception("La id no puede ser null.");
            _repositorioCategoria.Delete(id);      
         }
    }
}
