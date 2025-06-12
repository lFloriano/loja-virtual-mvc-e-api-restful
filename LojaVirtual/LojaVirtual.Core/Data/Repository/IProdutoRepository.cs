using LojaVirtual.Core.Application.Models;

namespace LojaVirtual.Core.Data.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodosAsync();
        Task<Produto?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task RemoverAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}
