using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.DTOs
{
    public record AltaGastoDTO
    {
            public string Descripcion { get; set; }
            public int Precio { get; set; }
            public int CategoriaId { get; set; }
            public DateTime Fecha { get; set; }
        
    }
}
