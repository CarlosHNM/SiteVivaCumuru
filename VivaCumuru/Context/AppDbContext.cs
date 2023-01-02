using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VivaCumuru.Models;

namespace VivaCumuru.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }

        public DbSet<TBAnexo> TBAnexo { get; set;}
        public DbSet<TelefoneUteis> TelefoneUteis { get;set; }

    }
}
