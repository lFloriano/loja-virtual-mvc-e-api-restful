using LojaVirtual.Core.Application.Models;
using LojaVirtual.Core.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Client.Controllers
{
    public class ProdutosController : Controller
    {
        readonly IProdutoRepository _produtoRepository;
        readonly ICategoriaRepository _categoriaRepository;
        readonly IVendedorRepository _vendedorRepository;

        public ProdutosController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository, IVendedorRepository vendedorRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _vendedorRepository = vendedorRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.ObterTodosAsync();
            return View(produtos);
        }

        [HttpGet("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoRepository.ObterPorIdAsync(id.Value);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpGet("novo")]
        public async Task<IActionResult> Create()
        {
            await CarregarDropDownLists();
            return View();
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendedorId,CategoriaId,Nome,Descricao,Preco,Imagem,Estoque")] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                await CarregarDropDownLists();
                return View(produto);
            }

            await _produtoRepository.AdicionarAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoRepository.ObterPorIdAsync(id.Value);

            if (produto == null)
            {
                return NotFound();
            }

            await CarregarDropDownLists();
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
                await CarregarDropDownLists();
                return View(produto);
            }

            try
            {
                await _produtoRepository.AtualizarAsync(produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await _produtoRepository.ExisteAsync(id)))
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

            var produto = await _produtoRepository.ObterPorIdAsync(id.Value);

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
            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if (produto != null)
            {
                await _produtoRepository.RemoverAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task CarregarDropDownLists(int? idCategoriaSelecionada = null, int? idVendedorSelecionado = null)
        {
            ViewData["CategoriaId"] = idCategoriaSelecionada.HasValue ?
                new SelectList(await _categoriaRepository.ObterTodosAsync(), "Id", "Descricao", idCategoriaSelecionada) :
                new SelectList(await _categoriaRepository.ObterTodosAsync(), "Id", "Descricao");

            ViewData["VendedorId"] = idVendedorSelecionado.HasValue ?
                new SelectList(await _vendedorRepository.ObterTodosAsync(), "Id", "Nome", idVendedorSelecionado) :
                new SelectList(await _vendedorRepository.ObterTodosAsync(), "Id", "Nome");
        }
    }
}
