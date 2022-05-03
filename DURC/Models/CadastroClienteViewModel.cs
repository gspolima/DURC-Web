using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DURC.Models
{
    public class CadastroClienteViewModel
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(11, ErrorMessage = "Apenas 11 dígitos")]
        [MinLength(11, ErrorMessage = "Apenas 11 dígitos")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(11, ErrorMessage = "Até 11 dígitos")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Estado { get; set; }
    }
}
