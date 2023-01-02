using VivaCumuru.Models;

namespace VivaCumuru.Repositories.Interfaces
{
    public interface ILojaRepository
    {
       IEnumerable<Loja> Lojas { get; }
        Loja GetLojaById(int LojaId);
    }
}
