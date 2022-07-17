using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEstoque.Models;
using GestaoEstoque.DataBase;

namespace ControleEstoque.Controllers
{
    public class SaidasController : Controller
    {
        private readonly Contexto _context;

        public SaidasController(Contexto context)
        {
            _context = context;
        }

        // GET: Saidas
        public async Task<IActionResult> Index()
        {
              return _context.Saida != null ? 
                          View(await _context.Saida.ToListAsync()) :
                          Problem("Entity set 'Contexto.Saida'  is null.");
        }

        // GET: Saidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Saida == null)
            {
                return NotFound();
            }

            var saida = await _context.Saida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saida == null)
            {
                return NotFound();
            }

            return View(saida);
        }

        // GET: Saidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Saidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lote,NomeProduto,Quantidade,Retirada,Validade")] Saida saida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saida);
        }

        // GET: Saidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Saida == null)
            {
                return NotFound();
            }

            var saida = await _context.Saida.FindAsync(id);
            if (saida == null)
            {
                return NotFound();
            }
            return View(saida);
        }

        // POST: Saidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lote,NomeProduto,Quantidade,Retirada,Validade")] Saida saida)
        {
            
            if (id != saida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaidaExists(saida.Id))
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
            return View(saida);
        }

        // GET: Saidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Saida == null)
            {
                return NotFound();
            }

            var saida = await _context.Saida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saida == null)
            {
                return NotFound();
            }

            return View(saida);
        }

        // POST: Saidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Saida == null)
            {
                return Problem("Entity set 'Contexto.Saida'  is null.");
            }
            var saida = await _context.Saida.FindAsync(id);
            if (saida != null)
            {
                _context.Saida.Remove(saida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaidaExists(int id)
        {
          return (_context.Saida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
