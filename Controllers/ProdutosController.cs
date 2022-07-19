using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestao_Estoque_Mvc.Data;
using Gestao_Estoque_Mvc.Models;

namespace Gestao_Estoque_Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto _context;

        public ProdutosController(Contexto context)
        {
            _context = context;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
            return _context.Produtos != null ?
                        View(await _context.Produtos.ToListAsync()) :
                        Problem("Entity set 'Contexto.Estoque'  is null.");
        }

        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var estoque = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lote,NomeProduto,Quantidade,Recebimento,Validade")] Produto estoque, Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estoque);
                _context.Add(entrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var estoque = await _context.Produtos.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lote,NomeProduto,Quantidade,Recebimento,Validade")] Produto estoque)
        {
            if (id != estoque.Id)
            {
                return NotFound();
            }
            var qntd = estoque.Quantidade;
            if (ModelState.IsValid)
            {

                try
                {

                    _context.Update(estoque);
                    await _context.SaveChangesAsync();


                    if (estoque.Quantidade <= 0)
                    {
                        _context.Remove(estoque);
                        await _context.SaveChangesAsync();
                        TempData["MensagemSucesso"] = "Produto acabou e foi retirado com sucesso!";
                        return RedirectToAction(nameof(Index));
                    }

                    if (estoque.Quantidade == 1)
                    {
                        TempData["MensagemSucesso"] = $"Resta apenas {estoque.Quantidade} produto desse lote!";

                    }
                    else if (estoque.Quantidade > 1)
                    {
                        TempData["MensagemSucesso"] = $"Restam apenas {estoque.Quantidade} produtos desse lote!";

                    }



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(estoque.Id))
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
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var estoque = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'Contexto.Estoque'  is null.");
            }
            var estoque = await _context.Produtos.FindAsync(id);
            if (estoque != null)
            {
                _context.Produtos.Remove(estoque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
