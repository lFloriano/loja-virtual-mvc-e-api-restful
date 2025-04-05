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
            Initialize();
        }

        public DbSet<Categoria> Categoria { get; set; }
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
            Categoria.AddRange(
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
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Vendedor)
                .WithMany()
                .HasForeignKey(p => p.VendedorId);
        }
    }
}
