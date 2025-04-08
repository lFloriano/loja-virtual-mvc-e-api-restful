using LojaVirtual.Core.Application.Models;

namespace LojaVirtual.Core.Data
{
    public class LojaVirtualInitializer
    {
        private readonly LojaVirtualContext _context;

        public LojaVirtualInitializer(LojaVirtualContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                AdicionarCategoriasIniciais();
                AdicionarVendedorInical();
                _context.SaveChanges();

                AdicionarProdutosIniciais();
                _context.SaveChanges();
            }
        }

        private void AdicionarCategoriasIniciais()
        {
            _context.Categorias.AddRange(
                new Categoria { Nome = "Eletrônicos", Descricao = "Equipamentos Eletrônicos" },
                new Categoria { Nome = "Roupas", Descricao = "Roupas masculinas e femininas" },
                new Categoria { Nome = "Livros", Descricao = "Livros físicos e e-books" }
            );
        }

        private void AdicionarVendedorInical()
        {
            _context.Vendedores.AddRange(
                new Vendedor { Nome = "Vendedor 1", Email = "Vendedor@lojavirtual.com", DataCadastro = DateTime.Now },
                new Vendedor { Nome = "Vendedor 2", Email = "Vendedor2@lojavirtual.com", DataCadastro = DateTime.Now }
            );
        }

        private void AdicionarProdutosIniciais()
        {
            _context.Produtos.AddRange(
                new Produto
                {
                    Nome = "Smartphone",
                    Descricao = "Smartphone de última geração",
                    Preco = 2999.99m,
                    Estoque = 50,
                    Imagem = "smartphone.jpg",
                    CategoriaId = 1,
                    VendedorId = 1
                },
                new Produto
                {
                    Nome = "Camiseta",
                    Descricao = "Camiseta de algodão",
                    Preco = 49.99m,
                    Estoque = 200,
                    Imagem = "camiseta.jpg",
                    CategoriaId = 2,
                    VendedorId = 2
                },
                new Produto
                {
                    Nome = "Livro de Programação",
                    Descricao = "Livro sobre C# avançado",
                    Preco = 89.99m,
                    Estoque = 100,
                    Imagem = "livro_programacao.jpg",
                    CategoriaId = 3,
                    VendedorId = 1
                }
            );
        }
    }
}
