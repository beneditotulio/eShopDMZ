using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShopDMZ.Models
{
    public class TBProduto
    {
        [Key]
        public int IDProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        public int IDCategoria { get; set; }
        public int IDFornecedor { get; set; }
        public byte[] Imagem { get; set; }

        public virtual TBCategoria TBCategoria { get; set; }
        public  virtual TBFornecedor TBFornecedor { get; set; }

        public string forn { get; set; }
        public string cat { get; set; }
        //public virtual TBCategoria TBCategoria { get; set; }

        public ICollection<Models.TBImagem> TBImagem { get; set; }
        public ICollection<Models.TBVendidos> TBVendidos { get; set; }

    }
}
