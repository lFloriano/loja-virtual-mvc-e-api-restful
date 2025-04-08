using LojaVirtual.Core.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Core.Data
{
    public class LojaVirtualContext : DbContext
    {
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options)
            : base(options)
        {
            Initialize();
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MapearRelacionamentos(modelBuilder);
        }

        private void Initialize()
        {
            if (Database.EnsureCreated())
            {
                AdicionarCategoriasIniciais();
                AdicionarVendedorInical();
                SaveChanges();
            }
        }

        private void AdicionarCategoriasIniciais()
        {
            Categorias.AddRange(
                new Categoria { Nome = "Eletrônicos", Descricao = "Equipamentos Eletrônicos" },
                new Categoria { Nome = "Roupas", Descricao = "Roupas masculinas e femininas" },
                new Categoria { Nome = "Livros", Descricao = "Livros físicos e e-books" }
            );
        }

        private void AdicionarVendedorInical()
        {
            Vendedores.Add(
                new Vendedor { Nome = "Vendedor 1", Email = "Vendedor@lojavirtual.com", DataCadastro = DateTime.Now }
            );
        }

        private void MapearRelacionamentos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Vendedor)
                .WithMany()
                .HasForeignKey(p => p.VendedorId);
        }
    }
}
