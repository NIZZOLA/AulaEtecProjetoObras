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
    public class EmpreendimentosController : ControllerBase
    {
        private readonly ObraMVCContext _context;

        public EmpreendimentosController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: Empreendimentos
        public async Task<IActionResult> Index()
        {
            CreateViewBags();
            var obraMVCContext = _context.Empreendimentos.Include(e => e.Cliente);
            return View(await obraMVCContext.ToListAsync());
        }

        // GET: Empreendimentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.Empreendimentos == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.Empreendimentos
                .Include(e => e.Cliente)
                .Include(e => e.Contas)
                .Include(e => e.Fotos)
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
            CreateViewBags();
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "NomeDoCliente");
            return View();
        }

        // POST: Empreendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,ClienteId,DataOrcamento,DataInicio,DataPrevistaTermino,DataTermino,Logradouro,Numero,Bairro,Cidade,Estado,Cep,Latitude,Longitude,Id")] EmpreendimentoModel empreendimentoModel)
        {
            CreateViewBags();
            if (ModelState.IsValid)
            {
                _context.Add(empreendimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Bairro", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // GET: Empreendimentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.Empreendimentos == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.Empreendimentos.FindAsync(id);
            if (empreendimentoModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Bairro", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // POST: Empreendimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Nome,ClienteId,DataOrcamento,DataInicio,DataPrevistaTermino,DataTermino,Logradouro,Numero,Bairro,Cidade,Estado,Cep,Latitude,Longitude,Id")] EmpreendimentoModel empreendimentoModel)
        {
            CreateViewBags();
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
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Bairro", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // GET: Empreendimentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.Empreendimentos == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.Empreendimentos
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
            CreateViewBags();
            if (_context.Empreendimentos == null)
            {
                return Problem("Entity set 'ObraMVCContext.EmpreendimentoModel'  is null.");
            }
            var empreendimentoModel = await _context.Empreendimentos.FindAsync(id);
            if (empreendimentoModel != null)
            {
                _context.Empreendimentos.Remove(empreendimentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpreendimentoModelExists(Guid? id)
        {
          return (_context.Empreendimentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
