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
    public class EmpreendimentosController : Controller
    {
        private readonly ObraMVCContext _context;

        public EmpreendimentosController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: Empreendimentos
        public async Task<IActionResult> Index()
        {
            var obraMVCContext = _context.EmpreendimentoModel.Include(e => e.Cliente);
            return View(await obraMVCContext.ToListAsync());
        }

        // GET: Empreendimentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EmpreendimentoModel == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.EmpreendimentoModel
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empreendimentoModel == null)
            {
                return NotFound();
            }

            return View(empreendimentoModel);
        }

        // GET: Empreendimentos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClienteFornecedorModel, "Id", "Bairro");
            return View();
        }

        // POST: Empreendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,ClienteId,DataOrcamento,DataInicio,DataPrevistaTermino,DataTermino,Logradouro,Numero,Bairro,Cidade,Estado,Cep,Latitude,Longitude,Id")] EmpreendimentoModel empreendimentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empreendimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteFornecedorModel, "Id", "Bairro", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // GET: Empreendimentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EmpreendimentoModel == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.EmpreendimentoModel.FindAsync(id);
            if (empreendimentoModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteFornecedorModel, "Id", "Bairro", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // POST: Empreendimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Nome,ClienteId,DataOrcamento,DataInicio,DataPrevistaTermino,DataTermino,Logradouro,Numero,Bairro,Cidade,Estado,Cep,Latitude,Longitude,Id")] EmpreendimentoModel empreendimentoModel)
        {
            if (id != empreendimentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empreendimentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpreendimentoModelExists(empreendimentoModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteFornecedorModel, "Id", "Bairro", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // GET: Empreendimentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EmpreendimentoModel == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.EmpreendimentoModel
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empreendimentoModel == null)
            {
                return NotFound();
            }

            return View(empreendimentoModel);
        }

        // POST: Empreendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.EmpreendimentoModel == null)
            {
                return Problem("Entity set 'ObraMVCContext.EmpreendimentoModel'  is null.");
            }
            var empreendimentoModel = await _context.EmpreendimentoModel.FindAsync(id);
            if (empreendimentoModel != null)
            {
                _context.EmpreendimentoModel.Remove(empreendimentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpreendimentoModelExists(Guid? id)
        {
          return (_context.EmpreendimentoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
