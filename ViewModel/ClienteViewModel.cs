using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBank.ViewModel
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o cpf")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

    }
}
