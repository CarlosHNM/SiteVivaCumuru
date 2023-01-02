using VivaCumuru.Models;

namespace VivaCumuru.ViewModels
{
    public class LojaListViewModel
    {
        public IEnumerable<Loja> Lojas { get; set; }
        public string SubCategoriaAtual { get; set; }
    }
}
