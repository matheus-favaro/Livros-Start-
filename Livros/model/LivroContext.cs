using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Livros.model
{
    public class LivroContext
    {
        public object Livros { get; internal set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options) : base(options)
        {
            Database.EnsureCreated;
        }

        public DbSet<Livro> Livro { get; set; }
    }
}
