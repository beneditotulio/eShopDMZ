using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShopDMZ.Models
{
    public class TBVendidos
    {
        [Key]
        public int IDV { get; set; }
        public int IDCliente { get; set; }
        public int IDProduto { get; set; }
        public int Quantidade { get; set; }
        public int Total { get; set; }
        public ICollection<TBCliente> TBCliente { get; set; }
        public ICollection<TBProduto> TBProduto { get; set; }
    }
}
