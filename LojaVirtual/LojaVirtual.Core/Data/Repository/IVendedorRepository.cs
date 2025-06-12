using LojaVirtual.Core.Application.Models;

namespace LojaVirtual.Core.Data.Repository
{
    public interface IVendedorRepository
    {
        Task<IEnumerable<Vendedor>> ObterTodosAsync();
        Task<Vendedor?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Vendedor produto);
        Task AtualizarAsync(Vendedor produto);
        Task RemoverAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}
