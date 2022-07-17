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
    public class EstoquesController : Controller
    {
        private readonly Contexto _context;

        public EstoquesController(Contexto context)
        {
            _context = context;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
              return _context.Estoque != null ? 
                          View(await _context.Estoque.ToListAsync()) :
                          Problem("Entity set 'Contexto.Estoque'  is null.");
        }

        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque
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
        public async Task<IActionResult> Create([Bind("Id,Lote,NomeProduto,Quantidade,Recebimento,Validade")] Estoque estoque,Entrada entrada)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(estoque);
                    _context.Add(entrada);
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                return View(estoque);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,teve um erro ao cadastrar o produto,tente novamente!{erro.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lote,NomeProduto,Quantidade,Recebimento,Validade")] Estoque estoque)
        {
            try
            {
                if (id != estoque.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(estoque);
                        await _context.SaveChangesAsync();
                        
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
                    TempData["MensagemSucesso"] = "Produto atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                
                return View(estoque);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,teve um erro ao atualizar o produto,tente novamente!{erro.Message}";
                return RedirectToAction(nameof(Index));
            }
            
        }

        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque
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
            try
            {
                if (_context.Estoque == null)
                {
                    return Problem("Entity set 'Contexto.Estoque'  is null.");
                }
                var estoque = await _context.Estoque.FindAsync(id);
                if (estoque != null)
                {
                    _context.Estoque.Remove(estoque);
                }

                await _context.SaveChangesAsync();
                TempData["MensagemSucesso"] = "Produto apagado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,teve um erro ao apagar o produto,tente novamente!{erro.Message}";

                return RedirectToAction(nameof(Index));
            }
        }

        private bool EstoqueExists(int id)
        {
          return (_context.Estoque?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Sobra(int id, [Bind("Id,Lote,NomeProduto,Quantidade,Recebimento,Validade")] Estoque estoque)
        {
            try
            {
                if (id != estoque.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(estoque);
                        await _context.SaveChangesAsync();

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
                    TempData["MensagemSucesso"] = "Produto atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

                return View(estoque);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,teve um erro ao atualizar o produto,tente novamente!{erro.Message}";
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
