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
    public class TipoDePagamentosController : ControllerBase
    {
        private readonly ObraMVCContext _context;

        public TipoDePagamentosController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: TipoDePagamentos
        public async Task<IActionResult> Index()
        {
            CreateViewBags();
            return _context.TiposDePagamentos != null ? 
                          View(await _context.TiposDePagamentos.ToListAsync()) :
                          Problem("Entity set 'ObraMVCContext.TipoDePagamentoModel'  is null.");
        }

        // GET: TipoDePagamentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.TiposDePagamentos == null)
            {
                return NotFound();
            }

            var tipoDePagamentoModel = await _context.TiposDePagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDePagamentoModel == null)
            {
                return NotFound();
            }

            return View(tipoDePagamentoModel);
        }

        // GET: TipoDePagamentos/Create
        public IActionResult Create()
        {
            CreateViewBags();
            return View();
        }

        // POST: TipoDePagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id")] TipoDePagamentoModel tipoDePagamentoModel)
        {
            CreateViewBags();
            if (ModelState.IsValid)
            {
                _context.Add(tipoDePagamentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDePagamentoModel);
        }

        // GET: TipoDePagamentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.TiposDePagamentos == null)
            {
                return NotFound();
            }

            var tipoDePagamentoModel = await _context.TiposDePagamentos.FindAsync(id);
            if (tipoDePagamentoModel == null)
            {
                return NotFound();
            }
            return View(tipoDePagamentoModel);
        }

        // POST: TipoDePagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Nome,Id")] TipoDePagamentoModel tipoDePagamentoModel)
        {
            CreateViewBags();
            if (id != tipoDePagamentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDePagamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDePagamentoModelExists(tipoDePagamentoModel.Id))
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
            return View(tipoDePagamentoModel);
        }

        // GET: TipoDePagamentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.TiposDePagamentos == null)
            {
                return NotFound();
            }

            var tipoDePagamentoModel = await _context.TiposDePagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDePagamentoModel == null)
            {
                return NotFound();
            }

            return View(tipoDePagamentoModel);
        }

        // POST: TipoDePagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            CreateViewBags();
            if (_context.TiposDePagamentos == null)
            {
                return Problem("Entity set 'ObraMVCContext.TipoDePagamentoModel'  is null.");
            }
            var tipoDePagamentoModel = await _context.TiposDePagamentos.FindAsync(id);
            if (tipoDePagamentoModel != null)
            {
                _context.TiposDePagamentos.Remove(tipoDePagamentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDePagamentoModelExists(Guid? id)
        {
          return (_context.TiposDePagamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
