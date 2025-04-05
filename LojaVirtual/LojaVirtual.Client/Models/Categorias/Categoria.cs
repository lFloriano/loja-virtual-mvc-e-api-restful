using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Client.Models.Categorias
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        //[RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "O campo {0} só pode conter letras e espaços.")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        //[RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "O campo {0} só pode conter letras e espaços.")]
        public string Descricao { get; set; } = string.Empty;
    }
}
