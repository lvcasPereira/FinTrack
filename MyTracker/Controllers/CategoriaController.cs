using LogicaAplicacion.CasosDeUso;
using LogicaNegocio.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        
            private readonly AltaCategoria _altaCategoria;
            private readonly ListarCategoria _listarCategorias;
            private readonly EditarCategoria _editarCategoria;
            private readonly EliminarCategoria _eliminarCategoria;

            public CategoriaController(AltaCategoria altaCategoria,
                                       ListarCategoria listarCategorias,
                                       EditarCategoria editarCategoria,
                                       EliminarCategoria eliminarCategoria)
            {
                _altaCategoria = altaCategoria;
                _listarCategorias = listarCategorias;
                _editarCategoria = editarCategoria;
                _eliminarCategoria = eliminarCategoria;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(_listarCategorias.Execute());
            }

            [HttpPost]
            public IActionResult Add([FromBody] AltaCategoriaDTO dto)
            {
                _altaCategoria.Execute(dto);
                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] AltaCategoriaDTO dto)
            {
                _editarCategoria.Execute(id, dto);
                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _eliminarCategoria.Execute(id);
                return Ok();
            }
        }
    }

