using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public class Endereco : Entity
    {
        public Fornecedor Fornecedor { get; set; }
        public Guid FornecedorId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro{ get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }


}
