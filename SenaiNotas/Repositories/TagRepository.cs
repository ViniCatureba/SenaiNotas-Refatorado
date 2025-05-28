using Microsoft.EntityFrameworkCore;
using SenaiNotas.Context;
using SenaiNotas.DTO;
using SenaiNotas.Interfaces;
using SenaiNotas.Models;

namespace SenaiNotas.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly SenaiNotesContext _context;

        public TagRepository(SenaiNotesContext context)
        {
            _context = context;
        }

        public async Task AtualizarTag(int id, CadastrarTagDTO tag)
        {
            var tagEncontrada = await _context.Tags.FindAsync(id);
            if (tagEncontrada == null)
            {
                throw new ArgumentException("Tag não encontrada.");
            }
            tagEncontrada.Nome = tag.Nome;

            await _context.SaveChangesAsync();


        }

        public async Task<Tag>? BuscarPorId(int idUsuario)
        {
            var tag = await _context.Tags.Where(c =>  c.IdUsuario == idUsuario).FirstOrDefaultAsync();
            return tag;
        }

        public async Task<Tag> BuscarPorUsuarioeId(int id, string nome)
        {
            return await _context.Tags.FirstOrDefaultAsync(c => c.IdUsuario == id && c.Nome == nome);
        }

        public async Task CriarTag(CadastrarTagDTO? tag)
        {
            var verificar = _context.Tags.AnyAsync(c => c.Nome == tag.Nome && c.IdUsuario == tag.IdUsuario);
            if (verificar != null)
            {
                throw new ArgumentException("Tag já existente");
            }
                var novaTag = new Tag
            {
                Nome = tag.Nome,
                IdUsuario = tag.IdUsuario
            };

            await _context.Tags.AddAsync(novaTag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleatarTag(int id)
        {
              var tag = await _context.Tags.FirstOrDefaultAsync(c => c.IdTag == id);
            if (tag == null)
            {
                throw new ArgumentException("Tag nao encontrado");
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tag>>? ListarTodas(int idUsuario)
        {
            return await _context.Tags.Where(c => c.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
