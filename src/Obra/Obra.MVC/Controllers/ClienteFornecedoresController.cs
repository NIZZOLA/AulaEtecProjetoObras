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
    public class ClienteFornecedoresController : ControllerBase
    {
        private readonly ObraMVCContext _context;

        public ClienteFornecedoresController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: ClienteFornecedores
        public async Task<IActionResult> Index()
        {
            CreateViewBags();

            return _context.ClientesFornecedores != null ? 
                          View(await _context.ClientesFornecedores.ToListAsync()) :
                          Problem("Entity set 'ObraMVCContext.ClienteFornecedorModel'  is null.");
        }

        // GET: ClienteFornecedores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            CreateViewBags();

            if (id == null || _context.ClientesFornecedores == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClientesFornecedores
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
            CreateViewBags();
            var cli = new ClienteFornecedorModel();
            cli.Cliente = true;
            return View(cli);
        }

        // POST: ClienteFornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cliente,Fornecedor,Nome,Cpf,DataDeNascimento,NomeFantasia,RazaoSocial,Cnpj,InscricaoEstadual,OptanteDoSimples,Observacoes,Logradouro,Numero,Bairro,Cidade,Estado,Cep,Latitude,Longitude,Id")] ClienteFornecedorModel clienteFornecedorModel)
        {
            CreateViewBags();

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
            CreateViewBags();

            if (id == null || _context.ClientesFornecedores == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClientesFornecedores.FindAsync(id);
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
            CreateViewBags();

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
            CreateViewBags();

            if (id == null || _context.ClientesFornecedores == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClientesFornecedores
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
            CreateViewBags();

            if (_context.ClientesFornecedores == null)
            {
                return Problem("Entity set 'ObraMVCContext.ClienteFornecedorModel'  is null.");
            }
            var clienteFornecedorModel = await _context.ClientesFornecedores.FindAsync(id);
            if (clienteFornecedorModel != null)
            {
                _context.ClientesFornecedores.Remove(clienteFornecedorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteFornecedorModelExists(Guid? id)
        {
          return (_context.ClientesFornecedores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
