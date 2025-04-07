using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Core.Application.Models
{
    public class Categoria
    {
        public int Id { get; set; }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Criacao{ get; set; }
    }
}
