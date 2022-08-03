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
    public class ClienteFornecedoresController : Controller
    {
        private readonly ObraMVCContext _context;

        public ClienteFornecedoresController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: ClienteFornecedores
        public async Task<IActionResult> Index()
        {
              return _context.ClienteFornecedorModel != null ? 
                          View(await _context.ClienteFornecedorModel.ToListAsync()) :
                          Problem("Entity set 'ObraMVCContext.ClienteFornecedorModel'  is null.");
        }

        // GET: ClienteFornecedores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ClienteFornecedorModel == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClienteFornecedorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteFornecedorModel == null)
            {
                return NotFound();
            }

            return View(clienteFornecedorModel);
        }

        // GET: ClienteFornecedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteFornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cliente,Fornecedor,Nome,Cpf,DataDeNascimento,NomeFantasia,RazaoSocial,Cnpj,InscricaoEstadual,OptanteDoSimples,Observacoes,Logradouro,Numero,Bairro,Cidade,Estado,Cep,Latitude,Longitude,Id")] ClienteFornecedorModel clienteFornecedorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteFornecedorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteFornecedorModel);
        }

        // GET: ClienteFornecedores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ClienteFornecedorModel == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClienteFornecedorModel.FindAsync(id);
            if (clienteFornecedorModel == null)
            {
                return NotFound();
            }
            return View(clienteFornecedorModel);
        }

        // POST: ClienteFornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Cliente,Fornecedor,Nome,Cpf,DataDeNascimento,NomeFantasia,RazaoSocial,Cnpj,InscricaoEstadual,OptanteDoSimples,Observacoes,Logradouro,Numero,Bairro,Cidade,Estado,Cep,Latitude,Longitude,Id")] ClienteFornecedorModel clienteFornecedorModel)
        {
            if (id != clienteFornecedorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteFornecedorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteFornecedorModelExists(clienteFornecedorModel.Id))
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
            return View(clienteFornecedorModel);
        }

        // GET: ClienteFornecedores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ClienteFornecedorModel == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClienteFornecedorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteFornecedorModel == null)
            {
                return NotFound();
            }

            return View(clienteFornecedorModel);
        }

        // POST: ClienteFornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.ClienteFornecedorModel == null)
            {
                return Problem("Entity set 'ObraMVCContext.ClienteFornecedorModel'  is null.");
            }
            var clienteFornecedorModel = await _context.ClienteFornecedorModel.FindAsync(id);
            if (clienteFornecedorModel != null)
            {
                _context.ClienteFornecedorModel.Remove(clienteFornecedorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteFornecedorModelExists(Guid? id)
        {
          return (_context.ClienteFornecedorModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
