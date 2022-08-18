using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obra.Domain.Models;
using Obra.MVC.Data;

namespace Obra.MVC.Controllers
{
    public class UsuariosController : ControllerBase
    {
        private readonly ObraMVCContext _context;

        public UsuariosController(ObraMVCContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            base.CreateViewBags();
              return _context.Usuarios != null ? 
                          View(await _context.Usuarios.ToListAsync()) :
                          Problem("Entity set 'ObraMVCContext.Usuarios'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            base.CreateViewBags();
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            base.CreateViewBags();
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Email,Password,Perfil,Id")] UsuarioModel usuarioModel)
        {
            base.CreateViewBags();
            if (ModelState.IsValid)
            {
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            base.CreateViewBags();
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuarios.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Username,Email,Password,Perfil,Id")] UsuarioModel usuarioModel)
        {
            base.CreateViewBags();
            if (id != usuarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.Id))
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
            return View(usuarioModel);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            base.CreateViewBags();
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            base.CreateViewBags();
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ObraMVCContext.Usuarios'  is null.");
            }
            var usuarioModel = await _context.Usuarios.FindAsync(id);
            if (usuarioModel != null)
            {
                _context.Usuarios.Remove(usuarioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(Guid? id)
        {
          return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
