using LogicaAplicacion.CasosDeUso;
using LogicaNegocio.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        
            private readonly AltaGasto _altaGasto;
            private readonly ListarGasto _listarGasto;
            private readonly EditarGasto _editarGasto;
            private readonly EliminarGasto _eliminarGasto;

            public GastoController(AltaGasto altaGasto,
                                       ListarGasto listarGasto,
                                       EditarGasto editarGasto,
                                       EliminarGasto eliminarGasto)
            {
            _altaGasto = altaGasto;
            _listarGasto = listarGasto;
            _editarGasto = editarGasto;
            _eliminarGasto = eliminarGasto;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(_listarGasto.Execute());
            }

            [HttpPost]
            public IActionResult Add([FromBody] AltaGastoDTO dto)
            {
            _altaGasto.Execute(dto);
                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] AltaGastoDTO dto)
            {
            _editarGasto.Execute(id, dto);
                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
            _eliminarGasto.Execute(id);
                return Ok();
            }
        }
    
}
