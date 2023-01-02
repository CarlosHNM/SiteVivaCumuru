using VivaCumuru.Context;
using VivaCumuru.Models;
using VivaCumuru.Repositories.Interfaces;

namespace VivaCumuru.Repositories
{
    public class SubCategoriaRepository : ISubCategoriaRepository
    {
        private readonly AppDbContext _context;

        public SubCategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SubCategoria> SubCategorias => _context.SubCategorias;
    }
}
