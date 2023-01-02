using Microsoft.AspNetCore.Mvc;
using VivaCumuru.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using VivaCumuru.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VivaCumuru.Aeras.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSubCategoriasController : Controller
    {
        private readonly AppDbContext _context;
        public AdminSubCategoriasController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Admin/AdminCategorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubCategorias.ToListAsync());
        }
        // GET: Admin/AdminCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategoria == null)
            {
                return NotFound();
            }

            return View(subCategoria);
        }

        // GET: Admin/AdminLojas/Create
        public IActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");

            return View();
        }

        // GET: Admin/AdminCategorias/Create
        // POST: Admin/AdminCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubCategoriaNome, CategoriaId")] SubCategoria subCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subCategoria);
        }

        // GET: Admin/AdminCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategorias.FindAsync(id);
            if (subCategoria == null)
            {
                return NotFound();
            }
            ViewBag.CategoriaId = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", subCategoria.CategoriaId);
            return View(subCategoria);
        }

        // POST: Admin/AdminCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubCategoriaNome,CategoriaId")] SubCategoria subCategoria)
        {
            if (id != subCategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoriaExists(subCategoria.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", subCategoria.CategoriaId);
            return View(subCategoria);
        }

        // GET: Admin/AdminCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategorias
                .Include(s=> s.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategoria == null)
            {
                return NotFound();
            }

            return View(subCategoria);
        }

        // POST: Admin/AdminCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategoria = await _context.SubCategorias.FindAsync(id);
            _context.SubCategorias.Remove(subCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoriaExists(int id)
        {
            return _context.SubCategorias.Any(e => e.Id == id);
        }
    }
}
