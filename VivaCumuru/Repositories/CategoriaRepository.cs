using VivaCumuru.Context;
using VivaCumuru.Models;
using VivaCumuru.Repositories.Interfaces;

namespace VivaCumuru.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
