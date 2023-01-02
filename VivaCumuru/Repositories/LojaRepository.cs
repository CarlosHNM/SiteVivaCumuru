using VivaCumuru.Context;
using VivaCumuru.Models;
using VivaCumuru.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VivaCumuru.Repositories
{
    public class LojaRepository : ILojaRepository
    {
        private readonly AppDbContext _context;
        public LojaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Loja> Lojas => _context.Lojas.Include(s => s.SubCategoria);

        public Loja GetLojaById(int LojaId)
        {
            return _context.Lojas.FirstOrDefault(l => l.LojaId == LojaId);
        }
    }
}
