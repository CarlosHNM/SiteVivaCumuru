using Microsoft.AspNetCore.Mvc;
using VivaCumuru.Models;
using VivaCumuru.ViewModels;
using VivaCumuru.Repositories.Interfaces;
using VivaCumuru.Context;

namespace VivaCumuru.Controllers
{
    public class LojaController : Controller
    {
        private readonly ILojaRepository _lojaRepository;
        private readonly AppDbContext _context;

        public LojaController(ILojaRepository lojaRepository, AppDbContext context)
        {
            _lojaRepository = lojaRepository;
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var loja = _context.Lojas.Where(s => s.SubCategoriaId.Equals(id)).OrderBy(c => c.Nome);
            return View(loja);
        }

        public IActionResult List(string subCategoria)
        {
            IEnumerable<Loja> lojas;
            string subCategoriaAtual = string.Empty;
            //string categoriaAtual = string.Empty;
            if(string.IsNullOrEmpty(subCategoria))
            {
                lojas = _lojaRepository.Lojas.OrderBy(l => l.LojaId);
                subCategoriaAtual = "Todas as Lojas Cadastradas";

            }
            else
            {
                lojas = _lojaRepository.Lojas
                         .Where(l => l.SubCategoria.SubCategoriaNome.Equals(subCategoria)).OrderBy(s => s.Nome);

                subCategoriaAtual = subCategoria;
            }
            var lojasListViewModel = new LojaListViewModel
            {
                Lojas = lojas,
                SubCategoriaAtual = subCategoriaAtual
            };
            return View(lojasListViewModel);
        }

        public IActionResult Details(int lojaId)
        {
            var loja = _lojaRepository.Lojas.FirstOrDefault(l => l.LojaId == lojaId);
            return View(loja);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Loja> lojas;
            string subCategoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(searchString))
            {
                lojas =_lojaRepository.Lojas.OrderBy(l =>l.LojaId);
                subCategoriaAtual = "Todas as Lojas";
            }
            else
            {
                lojas = _lojaRepository.Lojas.Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));
                if (lojas.Any())
                    subCategoriaAtual = "Lojas";
                else
                    subCategoriaAtual = "Nenhuma Loja foi encontrada";
            }
            return View("~/Views/Loja/List.cshtml", new LojaListViewModel { Lojas = lojas, SubCategoriaAtual = subCategoriaAtual });
        }
    }
}
