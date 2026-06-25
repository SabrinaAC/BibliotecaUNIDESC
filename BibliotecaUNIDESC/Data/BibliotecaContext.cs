using Microsoft.EntityFrameworkCore;
using BibliotecaUNIDESC.Models;

namespace BibliotecaUNIDESC.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
    }
}
