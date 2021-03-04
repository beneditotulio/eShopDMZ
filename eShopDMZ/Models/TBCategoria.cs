using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShopDMZ.Models
{
    public class TBCategoria
    {
        [Key]
        public int IDCategoria { get; set; }

        [Required(ErrorMessage ="Por favor insira a descricao")]
        [Display (Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<TBProduto> TBProduto { get; set; }
    }
}
