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
    public class FotoEmpreendimentosController : ControllerBase
    {
        private readonly ObraMVCContext _context;

        public FotoEmpreendimentosController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: FotoEmpreendimentos
        public async Task<IActionResult> Index()
        {
            var obraMVCContext = _context.FotoEmpreendimentoModel.Include(f => f.Empreendimento);
            return View(await obraMVCContext.ToListAsync());
        }

        // GET: FotoEmpreendimentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FotoEmpreendimentoModel == null)
            {
                return NotFound();
            }

            var fotoEmpreendimentoModel = await _context.FotoEmpreendimentoModel
                .Include(f => f.Empreendimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotoEmpreendimentoModel == null)
            {
                return NotFound();
            }

            return View(fotoEmpreendimentoModel);
        }

        // GET: FotoEmpreendimentos/Create
        public IActionResult Create()
        {
            ViewData["EmpreendimentoId"] = new SelectList(_context.EmpreendimentoModel, "Id", "Bairro");
            return View();
        }

        // POST: FotoEmpreendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpreendimentoId,NomeDoArquivo,Id")] FotoEmpreendimentoModel fotoEmpreendimentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotoEmpreendimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpreendimentoId"] = new SelectList(_context.EmpreendimentoModel, "Id", "Bairro", fotoEmpreendimentoModel.EmpreendimentoId);
            return View(fotoEmpreendimentoModel);
        }

        // GET: FotoEmpreendimentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FotoEmpreendimentoModel == null)
            {
                return NotFound();
            }

            var fotoEmpreendimentoModel = await _context.FotoEmpreendimentoModel.FindAsync(id);
            if (fotoEmpreendimentoModel == null)
            {
                return NotFound();
            }
            ViewData["EmpreendimentoId"] = new SelectList(_context.EmpreendimentoModel, "Id", "Bairro", fotoEmpreendimentoModel.EmpreendimentoId);
            return View(fotoEmpreendimentoModel);
        }

        // POST: FotoEmpreendimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("EmpreendimentoId,NomeDoArquivo,Id")] FotoEmpreendimentoModel fotoEmpreendimentoModel)
        {
            if (id != fotoEmpreendimentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotoEmpreendimentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotoEmpreendimentoModelExists(fotoEmpreendimentoModel.Id))
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
            ViewData["EmpreendimentoId"] = new SelectList(_context.EmpreendimentoModel, "Id", "Bairro", fotoEmpreendimentoModel.EmpreendimentoId);
            return View(fotoEmpreendimentoModel);
        }

        // GET: FotoEmpreendimentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FotoEmpreendimentoModel == null)
            {
                return NotFound();
            }

            var fotoEmpreendimentoModel = await _context.FotoEmpreendimentoModel
                .Include(f => f.Empreendimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotoEmpreendimentoModel == null)
            {
                return NotFound();
            }

            return View(fotoEmpreendimentoModel);
        }

        // POST: FotoEmpreendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.FotoEmpreendimentoModel == null)
            {
                return Problem("Entity set 'ObraMVCContext.FotoEmpreendimentoModel'  is null.");
            }
            var fotoEmpreendimentoModel = await _context.FotoEmpreendimentoModel.FindAsync(id);
            if (fotoEmpreendimentoModel != null)
            {
                _context.FotoEmpreendimentoModel.Remove(fotoEmpreendimentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoEmpreendimentoModelExists(Guid? id)
        {
          return (_context.FotoEmpreendimentoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
