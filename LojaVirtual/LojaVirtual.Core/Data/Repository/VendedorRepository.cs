namespace LojaVirtual.Core.Data.Repository
{
    using LojaVirtual.Core.Application.Models;
    using Microsoft.EntityFrameworkCore;

    public class VendedorRepository : IVendedorRepository
    {
        private readonly LojaVirtualContext _context;

        public VendedorRepository(LojaVirtualContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendedor>> ObterTodosAsync()
        {
            return await _context.Vendedores
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Vendedor?> ObterPorIdAsync(int id)
        {
            return await _context.Vendedores
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarAsync(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _context.Vendedores.AnyAsync(e => e.Id == id);
        }
    }
}
