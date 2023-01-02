using VivaCumuru.Context;
using VivaCumuru.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using VivaCumuru.Areas.Admin.Controllers;

namespace VivaCumuru.Aeras.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminLojasController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLojasController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var resultado = _context.Lojas.Include(l => l.SubCategoria).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.Contains(filter));
            }
            var model = await PagingList.CreateAsync(resultado, 20, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);

        }

        // GET: Admin/AdminLojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas
                .Include(l => l.SubCategoria)
                .FirstOrDefaultAsync(m => m.LojaId == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // GET: Admin/AdminLojas/Create
        public IActionResult Create()
        {

            ViewBag.SubCategoriaId = new SelectList(_context.SubCategorias, "Id", "SubCategoriaNome");
            return View();
        }

        // POST: Admin/AdminLojas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LojaId,Nome,Descricao,Endereco,Email,Telefone,ImagemUrl,Instagran,SubCategoriaId,UrlLocalizador,Funcionamento")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SubCategoriaId = new SelectList(_context.SubCategorias, "Id", "SubCategoriaNome", loja.SubCategoriaId);
            return View(loja);
        }

        // GET: Admin/AdminLojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas.FindAsync(id);
            if (loja == null)
            {
                return NotFound();
            }
            ViewBag.SubCategoriaId = new SelectList(_context.SubCategorias, "Id", "SubCategoriaNome", loja.SubCategoriaId);
            return View(loja);
        }

        // POST: Admin/AdminLojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LojaId,Nome,Descricao,Endereco,Email,Telefone,ImagemUrl,Instagran,SubCategoriaId,UrlLocalizador,Funcionamento")] Loja loja)
        {
            if (id != loja.LojaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LojaExists(loja.LojaId))
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
            ViewData["Id"] = new SelectList(_context.SubCategorias, "Id", "SubCategoriaNome", loja.SubCategoriaId);
            return View(loja);
        }

        // GET: Admin/AdminLojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas
                .Include(l => l.SubCategoria)
                .FirstOrDefaultAsync(m => m.LojaId == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // POST: Admin/AdminLojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loja = await _context.Lojas.FindAsync(id);
            _context.Lojas.Remove(loja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LojaExists(int id)
        {
            return _context.Lojas.Any(e => e.LojaId == id);
        }
    }
}