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
    public class TipoDeDespesaReceitasController : Controller
    {
        private readonly ObraMVCContext _context;

        public TipoDeDespesaReceitasController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: TipoDeDespesaReceitas
        public async Task<IActionResult> Index()
        {
              return _context.TipoDeDespesaReceitaModel != null ? 
                          View(await _context.TipoDeDespesaReceitaModel.ToListAsync()) :
                          Problem("Entity set 'ObraMVCContext.TipoDeDespesaReceitaModel'  is null.");
        }

        // GET: TipoDeDespesaReceitas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TipoDeDespesaReceitaModel == null)
            {
                return NotFound();
            }

            var tipoDeDespesaReceitaModel = await _context.TipoDeDespesaReceitaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeDespesaReceitaModel == null)
            {
                return NotFound();
            }

            return View(tipoDeDespesaReceitaModel);
        }

        // GET: TipoDeDespesaReceitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeDespesaReceitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoDeDespesaReceitaModel tipoDeDespesaReceitaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeDespesaReceitaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeDespesaReceitaModel);
        }

        // GET: TipoDeDespesaReceitas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TipoDeDespesaReceitaModel == null)
            {
                return NotFound();
            }

            var tipoDeDespesaReceitaModel = await _context.TipoDeDespesaReceitaModel.FindAsync(id);
            if (tipoDeDespesaReceitaModel == null)
            {
                return NotFound();
            }
            return View(tipoDeDespesaReceitaModel);
        }

        // POST: TipoDeDespesaReceitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Nome,Receita,Despesa,Id")] TipoDeDespesaReceitaModel tipoDeDespesaReceitaModel)
        {
            if (id != tipoDeDespesaReceitaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeDespesaReceitaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeDespesaReceitaModelExists(tipoDeDespesaReceitaModel.Id))
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
            return View(tipoDeDespesaReceitaModel);
        }

        // GET: TipoDeDespesaReceitas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TipoDeDespesaReceitaModel == null)
            {
                return NotFound();
            }

            var tipoDeDespesaReceitaModel = await _context.TipoDeDespesaReceitaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeDespesaReceitaModel == null)
            {
                return NotFound();
            }

            return View(tipoDeDespesaReceitaModel);
        }

        // POST: TipoDeDespesaReceitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.TipoDeDespesaReceitaModel == null)
            {
                return Problem("Entity set 'ObraMVCContext.TipoDeDespesaReceitaModel'  is null.");
            }
            var tipoDeDespesaReceitaModel = await _context.TipoDeDespesaReceitaModel.FindAsync(id);
            if (tipoDeDespesaReceitaModel != null)
            {
                _context.TipoDeDespesaReceitaModel.Remove(tipoDeDespesaReceitaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeDespesaReceitaModelExists(Guid? id)
        {
          return (_context.TipoDeDespesaReceitaModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
