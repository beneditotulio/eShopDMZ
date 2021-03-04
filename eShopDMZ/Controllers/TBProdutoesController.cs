using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eShopDMZ.Data;
using eShopDMZ.Models;

namespace eShopDMZ.Controllers
{
    public class TBProdutoesController : Controller
    {
        private readonly eShopContext _context;

        public TBProdutoesController(eShopContext context)
        {
            _context = context;
        }

        // GET: TBProdutoes
        public async Task<IActionResult> Index()
        {

            //LISTA DE PRODUTOS
            //return View(await _context.TBProduto.ToListAsync());

            var pdList = (from a in _context.TBProduto
                          join b in _context.TBCategoria on a.IDCategoria equals b.IDCategoria
                          join c in _context.TBFornecedor on a.IDFornecedor equals c.IDFornecedor

                          select new TBProduto()
                          {
                              IDProduto = a.IDProduto,
                              Descricao = a.Descricao,
                              Preco = a.Preco,
                              Cor = a.Cor,
                              Tamanho = a.Tamanho,
                              IDCategoria = a.IDCategoria,
                              IDFornecedor = a.IDFornecedor,
                              forn = c.Nome,
                              cat = b.Descricao
                              
                              

                          }).ToList();

            return View(pdList);


            //var produtos =
            //      _context.TBProduto
            //      .FromSqlInterpolated($"Select IDProduto, TBProduto.Descricao As Descricao, Preco, Cor, Tamanho, TBCategoria.Descricao As Categoria, TBFornecedor.Nome As Fornecedor From TBProduto, TBCategoria, TBFornecedor Where TBProduto.IDCategoria like TBCategoria.IDCategoria and TBProduto.IDFornecedor like TBFornecedor.IDFornecedor")
            //      .ToList();
            //foreach (var p in produtos)
            //{
            //    new TBProduto
            //    {
            //        IDProduto = p.IDProduto,
            //        Descricao = p.Descricao,
            //        Preco = p.Preco,
            //        Cor = p.Cor,
            //        Tamanho = p.Tamanho,
            //        IDCategoria = p.IDCategoria,
            //        IDFornecedor = p.IDFornecedor

            //    };
            //    return View(produtos);
            //}
            //try 
            //{
            //    var pdList = from a in _context.TBProduto
            //                 join b in _context.TBCategoria
            //                 on a.IDCategoria equals b.IDCategoria
            //                 into TBCategoria
            //                 from b in TBCategoria.DefaultIfEmpty()

            //                 select new TBProduto
            //                 {
            //                     IDProduto = a.IDProduto,
            //                     Descricao = a.Descricao,
            //                     Preco = a.Preco,
            //                     Cor = a.Cor,
            //                     Tamanho = a.Tamanho,
            //                     IDCategoria = a.IDCategoria,
            //                     IDFornecedor = a.IDFornecedor,

            //                    TBCategoria=b==null?"":b.Descricao
            //                 };

            //    return View(pdList);
            //}
            //catch(Exception ex)
            //{
            //    return View();
            //}
        }

        // GET: TBProdutoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBProduto = await _context.TBProduto
                .FirstOrDefaultAsync(m => m.IDProduto == id);
            if (tBProduto == null)
            {
                return NotFound();
            }

            return View(tBProduto);
        }

        // GET: TBProdutoes/Create
        public IActionResult Create()
        {
            LoadCategoria();
            LoadFornecedor();
            return View();
        }

        // POST: TBProdutoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDProduto,Descricao,Preco,Cor,Tamanho,IDCategoria,IDFornecedor,Imagem")] TBProduto tBProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBProduto);
        }

        // GET: TBProdutoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBProduto = await _context.TBProduto.FindAsync(id);
            if (tBProduto == null)
            {
                return NotFound();
            }
            return View(tBProduto);

        }

        // POST: TBProdutoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDProduto,Descricao,Preco,Cor,Tamanho,IDCategoria,IDFornecedor,Imagem")] TBProduto tBProduto)
        {
            if (id != tBProduto.IDProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBProdutoExists(tBProduto.IDProduto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tBProduto);
        }

        // GET: TBProdutoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBProduto = await _context.TBProduto
                .FirstOrDefaultAsync(m => m.IDProduto == id);
            if (tBProduto == null)
            {
                return NotFound();
            }

            return View(tBProduto);
        }

        // POST: TBProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBProduto = await _context.TBProduto.FindAsync(id);
            _context.TBProduto.Remove(tBProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBProdutoExists(int id)
        {
            return _context.TBProduto.Any(e => e.IDProduto == id);
        }

        private void LoadFornecedor()
        {
            try
            {
                List<TBFornecedor> fornecedorlist = new List<TBFornecedor>();
                fornecedorlist = _context.TBFornecedor.ToList();
                fornecedorlist.Insert(0, new TBFornecedor { IDFornecedor = 0, Nome = "Por favor selecione o Fornecedor" });
                
                ViewBag.FornecedorList = fornecedorlist;
            }
            catch(Exception ex)
            {
                
            }
        }
        private void LoadCategoria()
        {
            try
            {
                List<TBCategoria> categorialist = new List<TBCategoria>();
                categorialist = _context.TBCategoria.ToList();
                categorialist.Insert(0, new TBCategoria { IDCategoria = 0, Descricao = "Por favor selecione a Categoria" });

                ViewBag.CategoriaList = categorialist;
            }
            catch (Exception ex)
            {
                
            }
        }


    }

}
