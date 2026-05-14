using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.DTOs
{
    public record ListarGastoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string NombreCategoria { get; set; } 
        public DateTime Fecha { get; set; }
    }
}
