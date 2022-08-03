using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obra.Domain.Models;
using Obra.Infra.Data;

namespace Obra.MVC.Controllers
{
    public class ContasController : Controller
    {
        private readonly ObraMVCContext _context;

        public ContasController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: Contas
        public async Task<IActionResult> Index()
        {
            var obraMVCContext = _context.ContaModel.Include(c => c.Empreendimento).Include(c => c.TipoDePagamento);
            return View(await obraMVCContext.ToListAsync());
        }

        // GET: Contas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ContaModel == null)
            {
                return NotFound();
            }

            var contaModel = await _context.ContaModel
                .Include(c => c.Empreendimento)
                .Include(c => c.TipoDePagamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaModel == null)
            {
                return NotFound();
            }

            return View(contaModel);
        }

        // GET: Contas/Create
        public IActionResult Create()
        {
            ViewData["EmpreendimentoId"] = new SelectList(_context.EmpreendimentoModel, "Id", "Bairro");
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TipoDePagamentoModel, "Id", "Nome");
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpreendimentoId,Vencimento,DataDoPagamento,DataDaCompra,Valor,ValorPago,NumeroDoDocumento,Observacoes,TipoDeDespesaId,TipoDePagamentoId,Id")] ContaModel contaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpreendimentoId"] = new SelectList(_context.EmpreendimentoModel, "Id", "Bairro", contaModel.EmpreendimentoId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TipoDePagamentoModel, "Id", "Nome", contaModel.TipoDePagamentoId);
            return View(contaModel);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ContaModel == null)
            {
                return NotFound();
            }

            var contaModel = await _context.ContaModel.FindAsync(id);
            if (contaModel == null)
            {
                return NotFound();
            }
            ViewData["EmpreendimentoId"] = new SelectList(_context.EmpreendimentoModel, "Id", "Bairro", contaModel.EmpreendimentoId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TipoDePagamentoModel, "Id", "Nome", contaModel.TipoDePagamentoId);
            return View(contaModel);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("EmpreendimentoId,Vencimento,DataDoPagamento,DataDaCompra,Valor,ValorPago,NumeroDoDocumento,Observacoes,TipoDeDespesaId,TipoDePagamentoId,Id")] ContaModel contaModel)
        {
            if (id != contaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaModelExists(contaModel.Id))
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
            ViewData["EmpreendimentoId"] = new SelectList(_context.EmpreendimentoModel, "Id", "Bairro", contaModel.EmpreendimentoId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TipoDePagamentoModel, "Id", "Nome", contaModel.TipoDePagamentoId);
            return View(contaModel);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ContaModel == null)
            {
                return NotFound();
            }

            var contaModel = await _context.ContaModel
                .Include(c => c.Empreendimento)
                .Include(c => c.TipoDePagamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaModel == null)
            {
                return NotFound();
            }

            return View(contaModel);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.ContaModel == null)
            {
                return Problem("Entity set 'ObraMVCContext.ContaModel'  is null.");
            }
            var contaModel = await _context.ContaModel.FindAsync(id);
            if (contaModel != null)
            {
                _context.ContaModel.Remove(contaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaModelExists(Guid? id)
        {
          return (_context.ContaModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
