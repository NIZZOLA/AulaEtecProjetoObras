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
    public class TipoDeDespesaReceitasController : ControllerBase
    {
        private readonly ObraMVCContext _context;
        
        public TipoDeDespesaReceitasController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: TipoDeDespesaReceitas
        public async Task<IActionResult> Index()
        {
            CreateViewBags();
            
            return _context.TiposDeDespesaReceitas != null ? 
                          View(await _context.TiposDeDespesaReceitas.ToListAsync()) :
                          Problem("Entity set 'ObraMVCContext.TipoDeDespesaReceitaModel'  is null.");
        }

        // GET: TipoDeDespesaReceitas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.TiposDeDespesaReceitas == null)
            {
                return NotFound();
            }

            var tipoDeDespesaReceitaModel = await _context.TiposDeDespesaReceitas
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
            CreateViewBags();
            return View();
        }

        // POST: TipoDeDespesaReceitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoDeDespesaReceitaModel tipoDeDespesaReceitaModel)
        {
            CreateViewBags();
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
            CreateViewBags();
            if (id == null || _context.TiposDeDespesaReceitas == null)
            {
                return NotFound();
            }

            var tipoDeDespesaReceitaModel = await _context.TiposDeDespesaReceitas.FindAsync(id);
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
            CreateViewBags();
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
            CreateViewBags();
            if (id == null || _context.TiposDeDespesaReceitas == null)
            {
                return NotFound();
            }

            var tipoDeDespesaReceitaModel = await _context.TiposDeDespesaReceitas
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
            CreateViewBags();
            if (_context.TiposDeDespesaReceitas == null)
            {
                return Problem("Entity set 'ObraMVCContext.TipoDeDespesaReceitaModel'  is null.");
            }
            var tipoDeDespesaReceitaModel = await _context.TiposDeDespesaReceitas.FindAsync(id);
            if (tipoDeDespesaReceitaModel != null)
            {
                _context.TiposDeDespesaReceitas.Remove(tipoDeDespesaReceitaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeDespesaReceitaModelExists(Guid? id)
        {
          return (_context.TiposDeDespesaReceitas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
