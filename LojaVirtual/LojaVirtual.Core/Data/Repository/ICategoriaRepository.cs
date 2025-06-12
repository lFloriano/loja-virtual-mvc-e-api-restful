using LojaVirtual.Core.Application.Models;

namespace LojaVirtual.Core.Data.Repository
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ObterTodosAsync();
        Task<Categoria?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Categoria produto);
        Task AtualizarAsync(Categoria produto);
        Task RemoverAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}
