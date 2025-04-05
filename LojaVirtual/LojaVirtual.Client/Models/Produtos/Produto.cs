using LojaVirtual.Client.Models.Categorias;
using LojaVirtual.Client.Models.Vendedores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Client.Models.Produtos
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Vendedor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int VendedorId { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int CategoriaId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo {0} deve ser maior que zero.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        [Display(Name = "Imagem")]
        public string Imagem { get; set; } = string.Empty;

        [Display(Name = "Estoque")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O campo {0} deve ser um valor positivo.")]
        public int Estoque { get; set; }

        public Categoria? Categoria { get; set; } = null!;
        public Vendedor? Vendedor { get; set; } = null!;
    }
}
