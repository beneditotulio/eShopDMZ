using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShopDMZ.Models
{
    public class TBCliente
    {
        [Key]
        public int IDCliente { get; set; }
        
        [Required(ErrorMessage =("Por favor insira o nome"))]
        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento{ get; set; }
        public string Contacto { get; set; }
        public string  Endereco1 { get; set; }
        public string Endereco2 { get; set; }
        public string CodigoPostal { get; set; }
        public TBVendidos TBVendidos{ get; set; }
    }
}
