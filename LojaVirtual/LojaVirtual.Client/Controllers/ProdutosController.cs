using LojaVirtual.Client.Data;
using LojaVirtual.Client.Models.Produtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Client.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly LojaVirtualContext _context;

        public ProdutosController(LojaVirtualContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var produtos = _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Vendedor)
                .ToListAsync();

            return View(await produtos);
        }

        [HttpGet("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpGet("novo")]
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Descricao");
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Email");

            return View();
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendedorId,CategoriaId,Nome,Descricao,Preco,Imagem,Estoque")] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Descricao", produto.CategoriaId);
                ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Email", produto.VendedorId);

                return View(produto);
            }

            _context.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Descricao", produto.CategoriaId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Email", produto.VendedorId);

            return View(produto);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VendedorId,CategoriaId,Nome,Descricao,Preco,Imagem,Estoque")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Descricao", produto.CategoriaId);
                ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Email", produto.VendedorId);
                return View(produto);
            }

            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("deletar/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost("deletar/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
