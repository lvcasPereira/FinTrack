using LogicaNegocio.DTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.Mapper
{
    public class CategoriaMapper
    {

        public static ListarCategoriaDTO ToDto(Categoria cat)
        {
            ListarCategoriaDTO dto = new ListarCategoriaDTO
            {
                   Nombre = cat.Nombre.Value,
            };

            return dto;
        }

        public static IEnumerable<ListarCategoriaDTO> ToDtoList(IEnumerable<Categoria> categorias)
        {
            return categorias.Select(c => ToDto(c));
        }

        public static Categoria FromDTO(AltaCategoriaDTO dto)
        {
            return new Categoria(new VONombre(dto.Nombre));
        }
    }
}
