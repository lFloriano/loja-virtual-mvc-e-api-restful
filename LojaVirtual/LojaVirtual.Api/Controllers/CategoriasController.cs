using LojaVirtual.Core.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        List<Categoria> categorias = new List<Categoria>();

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Categoria>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            if (categorias == null || !categorias.Any())
            {
                return NoContent();
            }

            return Ok(categorias);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var categoria = categorias.FirstOrDefault(x => x.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            //TODO: referencia: aula "action results e Http status codes" aos 05:00 minutos
            return CreatedAtAction(nameof(Get), new { id = 1 }, categoria);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Categoria categoria)
        {
            var categoriaOriginal = categorias.FirstOrDefault(x => x.Id == id);

            if (categoriaOriginal == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var categoria = categorias.FirstOrDefault(x => x.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
