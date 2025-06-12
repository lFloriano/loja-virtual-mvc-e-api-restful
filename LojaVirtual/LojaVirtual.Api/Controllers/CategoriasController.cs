using LojaVirtual.Core.Application.Models;
using LojaVirtual.Core.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Api.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Categoria>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var categorias = await _categoriaRepository.ObterTodosAsync();

            if (categorias == null || !categorias.Any())
            {
                return NoContent();
            }

            return Ok(categorias);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            await _categoriaRepository.AdicionarAsync(categoria);
            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoriaEditada)
        {
            if (id != categoriaEditada.Id)
            {
                return BadRequest();
            }

            var categoriaOriginal = await _categoriaRepository.ObterPorIdAsync(id);

            if (categoriaOriginal == null)
            {
                return NotFound();
            }

            await _categoriaRepository.AtualizarAsync(categoriaEditada);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            if (categoria?.Produtos != null && categoria.Produtos.Any())
            {
                return (BadRequest("Não é possível excluir a categoria, pois ela possui produtos associados."));
            }

            await _categoriaRepository.RemoverAsync(id);
            return NoContent();
        }
    }
}
