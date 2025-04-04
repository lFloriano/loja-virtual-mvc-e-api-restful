using LojaVirtual.Client.Models.Categorias;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Client.Data
{
    public class LojaVirtualContext : DbContext
    {
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AdicionarCategoriasIniciais(modelBuilder);
        }

        private void AdicionarCategoriasIniciais(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Eletrônicos" },
                new Categoria { Id = 2, Nome = "Roupas" },
                new Categoria { Id = 3, Nome = "Livros" }
            );
        }
    }
}
