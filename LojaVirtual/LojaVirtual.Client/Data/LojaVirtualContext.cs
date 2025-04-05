using LojaVirtual.Client.Models.Categorias;
using LojaVirtual.Client.Models.Produtos;
using LojaVirtual.Client.Models.Vendedores;
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
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AdicionarCategoriasIniciais(modelBuilder);
            AdicionarVendedorInical(modelBuilder);
            MapearRelacionamentos(modelBuilder);
        }

        private void AdicionarCategoriasIniciais(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Eletrônicos", Descricao = "Equipamentos Eletrônicos" },
                new Categoria { Id = 2, Nome = "Roupas", Descricao = "Roupas masculinas e femininas" },
                new Categoria { Id = 3, Nome = "Livros", Descricao = "Livros físicos e e-books" }
            );
        }

        private void AdicionarVendedorInical(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendedor>().HasData(
                new Vendedor { Id = 1, Nome = "Vendedor 1", Email = "Vendedor@lojavirtual.com", DataCadastro = DateTime.Now }
            );
        }

        private void MapearRelacionamentos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Vendedor)
                .WithMany()
                .HasForeignKey(p => p.VendedorId);
        }
    }
}
