using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShopDMZ.Models
{
    public class TBImagem
    {
        [Key]
        public int IDImagem { get; set; }
        public  byte[] Imagem { get; set; }
        public int IDProduto { get; set; }
        public TBProduto TBProduto { get; set; }
    }
}
