using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Client.Models.Vendedores
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Email { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
