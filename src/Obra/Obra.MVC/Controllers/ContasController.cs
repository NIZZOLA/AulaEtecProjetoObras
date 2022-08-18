using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obra.Domain.Models;
using Obra.Infra.Data;
using Obra.MVC.Data;

namespace Obra.MVC.Controllers
{
    public class ContasController : ControllerBase
    {
        private readonly ObraMVCContext _context;

        public ContasController(ObraMVCContext context)
        {
            _context = context;
        }

        private void InstanceDropDowns(ContaModel conta)
        {
            ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos, "Id", "Nome", conta.EmpreendimentoId);
            ViewData["TipoDeDespesaId"] = new SelectList(_context.TiposDeDespesaReceitas, "Id", "Nome", conta.TipoDeDespesaId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TiposDePagamentos, "Id", "Nome", conta.TipoDePagamentoId);
        }

        // GET: Contas
        public async Task<IActionResult> Index(Guid? id)
        {
            CreateViewBags();
            if(id == null)
            {
                var obraMVCContext = _context.Contas.Include(c => c.Empreendimento).Include(c => c.TipoDePagamento);

                return View(await obraMVCContext.ToListAsync());
            }
            else
            {
                ViewBag.EmpreendimentoId = id.Value.ToString();
                ViewBag.NomeDoEmpreendimento = _context.Empreendimentos.Where(a => a.Id == id.Value).FirstOrDefault().Nome;
                var obraMVCContext = _context.Contas.Where(a => a.EmpreendimentoId == id.Value).Include(c => c.Empreendimento).Include(c => c.TipoDePagamento);

                return View(await obraMVCContext.ToListAsync());
            }
        }

        // GET: Contas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.Contas == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas
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
        public IActionResult Create(Guid? id)
        {
            ViewBag.EmpreendimentoId = id.Value.ToString();

            CreateViewBags();
            InstanceDropDowns(new ContaModel());
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpreendimentoId,Vencimento,DataDoPagamento,DataDaCompra,Valor,ValorPago,NumeroDoDocumento,Observacoes,TipoDeDespesaId,TipoDePagamentoId")] ContaModel contaModel)
        {
            CreateViewBags();
            if (ModelState.IsValid)
            
            {
                _context.Add(contaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = contaModel.EmpreendimentoId});
            }
            InstanceDropDowns(contaModel);
            return View(contaModel);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.Contas == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas.FindAsync(id);
            if (contaModel == null)
            {
                return NotFound();
            }
            InstanceDropDowns(contaModel);
            return View(contaModel);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("EmpreendimentoId,Vencimento,DataDoPagamento,DataDaCompra,Valor,ValorPago,NumeroDoDocumento,Observacoes,TipoDeDespesaId,TipoDePagamentoId,Id")] ContaModel contaModel)
        {
            CreateViewBags();
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
            InstanceDropDowns(contaModel);
            return View(contaModel);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.Contas == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas
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
            CreateViewBags();
            if (_context.Contas == null)
            {
                return Problem("Entity set 'ObraMVCContext.ContaModel'  is null.");
            }
            var contaModel = await _context.Contas.FindAsync(id);
            if (contaModel != null)
            {
                _context.Contas.Remove(contaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaModelExists(Guid? id)
        {
          return (_context.Contas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
