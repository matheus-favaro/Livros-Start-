using Livros.model;
using Livros.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livros.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepositorio _livroRepositorio;
        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        [HttpGet]
        public async Task<IEnumerable<Livro>> GetLivros()
        {
            return await _livroRepositorio.Get();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Livro>> GetLivros(int id)
        {
            return await _livroRepositorio.Get(id);
        }
    
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivros([FromBody] Livro livro)
        {
            var newLivro = await _livroRepositorio.Create(livro);
            return CreatedAtAction(nameof(GetLivros), new {id = newLivro.Id}, newLivro);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var livroToDelete = await _livroRepositorio.Get(id);

            if (livroToDelete == null)
                return NotFound();

            await _livroRepositorio.Delete(livroToDelete.Id);
            return NoContent();
            

        }

        [HttpPut]
        public async Task<ActionResult> PutLivros(int id,[FromBody] Livro livro)
        {
            if(id != livro.Id)
                return BadRequest();

                await _livroRepositorio.Update(livro);

            return NoContent();
    }

}
    