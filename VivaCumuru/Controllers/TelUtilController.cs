using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivaCumuru.Context;

namespace VivaCumuru.Controllers
{
    public class TelUtilController : Controller
    {
        private readonly AppDbContext _context;

        public TelUtilController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TelefoneUteis.OrderBy(t => t.TelNome).ToListAsync());
        }
    }
}
