using LogicaNegocio.DTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;

namespace LogicaAplicacion.Mapper
{
    public class GastoMapper
    {
        public static ListarGastoDTO ToDto(Gasto gasto)
        {
            ListarGastoDTO dto = new ListarGastoDTO
            {
                Id = gasto.Id,
                Descripcion = gasto.Descripcion.Value,
                Precio = gasto.Precio.Value,
                Fecha = gasto.Fecha,
                NombreCategoria = gasto.Categoria?.Nombre.Value
            };

            return dto;
        }

        public static IEnumerable<ListarGastoDTO> ToDtoList(IEnumerable<Gasto> gastos)
        {
            return gastos.Select(g => ToDto(g));
        }

        // En GastoMapper
        public static Gasto FromDTO(AltaGastoDTO dto)
        {
            return new Gasto(
                new VODescripcion(dto.Descripcion),
                new VOPrecio(dto.Precio),
                dto.CategoriaId,
                DateTime.Now
            );
        }
    }
}