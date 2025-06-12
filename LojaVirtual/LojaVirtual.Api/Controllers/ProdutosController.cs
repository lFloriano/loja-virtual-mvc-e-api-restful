using LojaVirtual.Core.Application.Models;
using LojaVirtual.Core.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Api.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var produtos = await _produtoRepository.ObterTodosAsync();

            if (produtos == null || !produtos.Any())
            {
                return NoContent();
            }

            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            await _produtoRepository.AdicionarAsync(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] Produto produtoEditado)
        {
            if (id != produtoEditado.Id)
            {
                return BadRequest();
            }

            var produtoOriginal = await _produtoRepository.ObterPorIdAsync(id);

            if (produtoOriginal == null)
            {
                return NotFound();
            }

            await _produtoRepository.AtualizarAsync(produtoEditado);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _produtoRepository.RemoverAsync(id);
            return NoContent();
        }
    }
}
