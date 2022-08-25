using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obra.Domain.Models;
using Obra.Domain.Tools;
using Obra.Infra.Data;
using Obra.MVC.Data;

namespace Obra.MVC.Controllers
{
    public class FotoEmpreendimentosController : ControllerBase
    {
        private readonly ObraMVCContext _context;
        private string pastaParaImagens = ".\\wwwroot\\imagens";
        public FotoEmpreendimentosController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: FotoEmpreendimentos
        public async Task<IActionResult> Index()
        {
            CreateViewBags();
            var obraMVCContext = _context.FotosEmpreendimentos.Include(f => f.Empreendimento);
            return View(await obraMVCContext.ToListAsync());
        }

        // GET: FotoEmpreendimentos/Create
        public IActionResult Create()
        {
            CreateViewBags();
            ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos, "Id", "Bairro");
            return View();
        }

        // POST: FotoEmpreendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpreendimentoId,Descricao,Id")] FotoEmpreendimentoModel fotoEmpreendimentoModel, IFormFile anexo)
        {
            CreateViewBags();
            if( ! FileTools.ValidaImagem(anexo))
            {
                return View(fotoEmpreendimentoModel);
            }

            if (ModelState.IsValid)
            {
                var nome = FileTools.SalvarArquivo(pastaParaImagens, anexo);
                fotoEmpreendimentoModel.NomeDoArquivo = nome;

                _context.Add(fotoEmpreendimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos, "Id", "Bairro", fotoEmpreendimentoModel.EmpreendimentoId);
            return View(fotoEmpreendimentoModel);
        }

        // GET: FotoEmpreendimentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            CreateViewBags();
            if (id == null || _context.FotosEmpreendimentos == null)
            {
                return NotFound();
            }

            var fotoEmpreendimentoModel = await _context.FotosEmpreendimentos
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
            CreateViewBags();
            if (_context.FotosEmpreendimentos == null)
            {
                return Problem("Entity set 'ObraMVCContext.FotoEmpreendimentoModel'  is null.");
            }
            var fotoEmpreendimentoModel = await _context.FotosEmpreendimentos.FindAsync(id);
            if (fotoEmpreendimentoModel != null)
            {
                var filename = pastaParaImagens + "\\" + fotoEmpreendimentoModel.NomeDoArquivo;
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);

                _context.FotosEmpreendimentos.Remove(fotoEmpreendimentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoEmpreendimentoModelExists(Guid? id)
        {
          return (_context.FotosEmpreendimentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
