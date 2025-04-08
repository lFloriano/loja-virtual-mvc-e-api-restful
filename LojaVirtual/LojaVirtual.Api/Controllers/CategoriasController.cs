using LojaVirtual.Core.Application.Models;
using LojaVirtual.Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Api.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        readonly LojaVirtualContext _context;

        public CategoriasController(LojaVirtualContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Categoria>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();

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
            var categoria = _context.Categorias.Include(x => x.Produtos).AsNoTracking().FirstOrDefault(x => x.Id == id);

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
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] Categoria categoriaEditada)
        {
            if (id != categoriaEditada.Id)
            {
                return BadRequest();
            }

            var categoriaOriginal = _context.Categorias.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (categoriaOriginal == null)
            {
                return NotFound();
            }

            _context.Categorias.Update(categoriaEditada);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var categoria = _context.Categorias
                .Include(x => x.Produtos)
                .FirstOrDefault(x => x.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            if (categoria?.Produtos != null && categoria.Produtos.Any())
            {
                return (BadRequest("Não é possível excluir a categoria, pois ela possui produtos associados."));
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
