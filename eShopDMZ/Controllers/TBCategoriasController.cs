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
    public class TBCategoriasController : Controller
    {
        private readonly eShopContext _context;

        public TBCategoriasController(eShopContext context)
        {
            _context = context;
        }

        // GET: TBCategorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBCategoria.ToListAsync());
        }

        // GET: TBCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBCategoria = await _context.TBCategoria
                .FirstOrDefaultAsync(m => m.IDCategoria == id);
            if (tBCategoria == null)
            {
                return NotFound();
            }

            return View(tBCategoria);
        }

        // GET: TBCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCategoria,Descricao")] TBCategoria tBCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBCategoria);
        }

        // GET: TBCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBCategoria = await _context.TBCategoria.FindAsync(id);
            if (tBCategoria == null)
            {
                return NotFound();
            }
            return View(tBCategoria);
        }

        // POST: TBCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDCategoria,Descricao")] TBCategoria tBCategoria)
        {
            if (id != tBCategoria.IDCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBCategoriaExists(tBCategoria.IDCategoria))
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
            return View(tBCategoria);
        }

        // GET: TBCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBCategoria = await _context.TBCategoria
                .FirstOrDefaultAsync(m => m.IDCategoria == id);
            if (tBCategoria == null)
            {
                return NotFound();
            }

            return View(tBCategoria);
        }

        // POST: TBCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBCategoria = await _context.TBCategoria.FindAsync(id);
            _context.TBCategoria.Remove(tBCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBCategoriaExists(int id)
        {
            return _context.TBCategoria.Any(e => e.IDCategoria == id);
        }
    }
}
