using Microsoft.AspNetCore.Mvc;
using VivaCumuru.Repositories.Interfaces;

namespace VivaCumuru.Componentes
{
    public class SubCategoriaMenu : ViewComponent
    {
        private readonly ISubCategoriaRepository _subCategoriaRepository;
        public SubCategoriaMenu(ISubCategoriaRepository subCategoriaRepository)
        {
            _subCategoriaRepository = subCategoriaRepository;
        }
        public IViewComponentResult Invoke()
        {
            var subCategorias = _subCategoriaRepository.SubCategorias.OrderBy(s => s.SubCategoriaNome);
            return View(subCategorias);
        }
    }
}
