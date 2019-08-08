using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public class Fornecedor : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome{ get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor {get; set; }
        public Endereco Endereco { get; set; }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
