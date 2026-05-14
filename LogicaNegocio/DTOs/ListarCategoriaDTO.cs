using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.DTOs
{
    public record ListarCategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
