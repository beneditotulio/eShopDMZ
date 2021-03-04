using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eShopDMZ.Models;

namespace eShopDMZ.Data
{
    public class eShopContext: DbContext
    {
        public eShopContext(DbContextOptions<eShopContext> options) : base(options)
        {

        }
        public DbSet<Models.TBFornecedor> TBFornecedor { get; set; }
        public DbSet<Models.TBCategoria> TBCategoria { get; set; }
        public DbSet<eShopDMZ.Models.TBProduto> TBProduto { get; set; }
    }
}
