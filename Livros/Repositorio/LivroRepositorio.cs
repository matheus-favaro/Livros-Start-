using Livros.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Livros.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        public readonly LivroContext _context;
        public LivroRepositorio(LivroContext context)

        {
            _context = context;
        }
        public async Task<Livro> Create(Livro livro)
        {
            _context.Livro.Add(livro);
           await _context.SaveChangesAsync();

            return livro;
        }

        public async Task Delete(int id)
        {
            var livroToDelete = await _context.Livro.FindAsync(id);
            _context.Livro.Remove(livroToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Livro>> Get()
        {
           return await _context.Livro.ToListAsync();
        }

        public async Task<Livro> Get(int id)
        {
            return await _context.Livro.FindAsync(id);
        }

        public async Task Update(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
