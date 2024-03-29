﻿using System;
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
    public class EntradasController : Controller
    {
        private readonly Contexto _context;

        public EntradasController(Contexto context)
        {
            _context = context;
        }

        // GET: Entradas
        public async Task<IActionResult> Index()
        {
            return _context.Entrada != null ?
                        View(await _context.Entrada.ToListAsync()) :
                        Problem("Entity set 'Contexto.Entrada'  is null.");
        }

        // GET: Entradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entrada == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // GET: Entradas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lote,NomeProduto,Quantidade,Recebimento,Validade")] Entrada entrada, Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(entrada);
                    //Adiciona tambem na tabela produto
                    _context.Add(produto);
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                return View(entrada);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, erro ao cadastrar o produto, tente novamente, erro: {erro} ";
                return RedirectToAction(nameof(Index));

            }
        }

        // GET: Entradas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entrada == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lote,NomeProduto,Quantidade,Recebimento,Validade")] Entrada entrada, Produto estoque)
        {
            try
            {
                if (id != entrada.Id)
                {
                    return NotFound();
                }

                // pegando a quantidade que resta no estoque
                var qntd = entrada.Quantidade;

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(entrada);
                        _context.Update(estoque);
                        await _context.SaveChangesAsync();
                        
                        // apaga produto caso o estoque tenha zerado 
                        if (estoque.Quantidade <= 0)
                        {
                            _context.Remove(entrada);
                            _context.Remove(estoque);
                            await _context.SaveChangesAsync();
                            TempData["MensagemSucesso"] = "Produto foi  retirado com sucesso!";
                            return RedirectToAction(nameof(Index));
                        }

                        // mensagem de quantidade restante
                        if (estoque.Quantidade == 1)
                        {
                            TempData["MensagemSucesso"] = "Produto atualizado com sucesso!";
                        }
                        // mensagem de quantidade restante plural
                        else if (estoque.Quantidade > 1)
                        {
                            TempData["MensagemSucesso"] = "Produto atualizado com sucesso!";
                        }

                    }
                    catch (DbUpdateConcurrencyException erro)
                    {
                        TempData["MensagemErro"] = $"Ops, erro ao atualizar o produto, tente novamente, erro: {erro} ";

                        if (!EntradaExists(entrada.Id))
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
                return View(entrada);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, erro ao atualizar o produto, tente novamente, erro: {erro} ";
                return RedirectToAction(nameof(Index));
            }

        }
        // GET: Entradas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entrada == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entrada == null)
            {
                return Problem("Entity set 'Contexto.Entrada'  is null.");
            }
            var entrada = await _context.Entrada.FindAsync(id);
            var estoque = await _context.Produtos.FindAsync(id);
            if (entrada != null)
            {
                _context.Entrada.Remove(entrada);

                //Remove tambem na tabela produto
                if (estoque != null) { _context.Produtos.Remove(estoque); }

            }

            await _context.SaveChangesAsync();
            TempData["MensagemSucesso"] = "Produto apagado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaExists(int id)
        {
            return (_context.Entrada?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
