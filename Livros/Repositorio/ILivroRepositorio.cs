using Livros.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livros.Repositorio
{
    public interface ILivroRepositorio
    {
        Task<IEnumerable<Livro>> Get();

        Task<Livro> Get(int Id);

        Task<Livro> Create(Livro livro);

        Task Update(Livro livro);

        Task Delete(int Id);

    }
}
