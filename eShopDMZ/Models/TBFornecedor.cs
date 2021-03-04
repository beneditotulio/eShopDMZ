using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShopDMZ.Models
{
    public class TBFornecedor
    {
        [Key]
        public int IDFornecedor { get; set; }
        [Required (ErrorMessage ="Por favor insira o nome do fornecedor")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Por favor insira o endereço")]
        [Display (Name = "Endereço")]
        public string Endereco { get; set; }

        public ICollection<TBProduto> TBProduto { get; set; }
    }
}
