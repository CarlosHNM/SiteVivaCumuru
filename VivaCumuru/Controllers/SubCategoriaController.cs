using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VivaCumuru.Context;
using VivaCumuru.Models;
using VivaCumuru.Repositories.Interfaces;
using VivaCumuru.ViewModels;

namespace VivaCumuru.Controllers
{
    public class SubCategoriaController : Controller
    {
        private readonly ISubCategoriaRepository _subCategoriaRepository;
        private readonly AppDbContext _context;

        public SubCategoriaController(ISubCategoriaRepository subCategoriaRepository, AppDbContext context)
        {
            _subCategoriaRepository = subCategoriaRepository;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var subcategoria = _context.SubCategorias.Where(s => s.CategoriaId.Equals(id)).OrderBy(c => c.SubCategoriaNome);
            return View(subcategoria);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                ?? HttpContext.TraceIdentifier
            });
        }
    }
}
