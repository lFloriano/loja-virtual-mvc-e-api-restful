using LojaVirtual.Core.Application.Models;
using LojaVirtual.Core.Data;
using LojaVirtual.Core.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Client.Controllers
{
    [Route("categorias")]
    public class CategoriasController : Controller
    {
        readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await _categoriaRepository.ObterTodosAsync());
        }

        [HttpGet("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _categoriaRepository.ObterPorIdAsync(id.Value);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpGet("novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaRepository.AdicionarAsync(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        [HttpGet("editar/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _categoriaRepository.ObterPorIdAsync(id.Value);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriaRepository.AtualizarAsync(categoria);
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!(await _categoriaRepository.ExisteAsync(categoria.Id)))
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
            return View(categoria);
        }

        [HttpGet("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _categoriaRepository.ObterPorIdAsync(id.Value);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if (categoria?.Produtos != null && categoria.Produtos.Any())
            {
                //TODO: melhorar exibição de mensagens vindas do backend
                ViewBag.Mensagens = "Não é possível excluir a categoria pois existem produtos vinculados a ela.";
                return View(categoria);
            }

            if (categoria != null)
            {
                await _categoriaRepository.RemoverAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
