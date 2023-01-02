using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VivaCumuru.Context;
using VivaCumuru.Models;

namespace VivaCumuru.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TelefoneUteisController : Controller
    {
        private readonly AppDbContext _context;

        public TelefoneUteisController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TelefoneUteis.OrderBy(t => t.TelNome).ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.TelefoneUteis
                .FirstOrDefaultAsync(m => m.TelId == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelId,TelNome,TelNum")] TelefoneUteis telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telefone);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.TelefoneUteis.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }
            return View(telefone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelId,TelNome,TelNum")] TelefoneUteis telefone)
        {
            if (id != telefone.TelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(telefone.TelId))
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
            return View(telefone);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.TelefoneUteis.FirstOrDefaultAsync(m => m.TelId == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefone = await _context.TelefoneUteis.FindAsync(id);
            _context.TelefoneUteis.Remove(telefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int id)
        {
            return _context.TelefoneUteis.Any(e => e.TelId == id);
        }
    }
}
