using Microsoft.EntityFrameworkCore;
using SenaiNotas.Context;
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

        public Task AtualizarTag(int id, Tag tag)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag>? BuscarPorId(int idUsuario)
        {
            var tag = await _context.Tags.Where(c =>  c.IdUsuario == idUsuario).FirstOrDefaultAsync();
            return tag;
        }

        public async Task<Tag> BuscarPorUsuarioeId(int id, string nome)
        {
            var tag = await _context.Tags.Where(c => c.IdUsuario == id && c.Nome == nome).FirstOrDefaultAsync();
            if (tag == null)
            {
                throw new ArgumentException("Cliente nao encontrado");
            }
            return tag;
        }

        public Task CriarTag(Tag? tag)
        {
            throw new NotImplementedException();
        }

        public async Task DeleatarTag(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(c => c.IdTag == id);
            if (tag == null)
            {
                throw new ArgumentException("Cliente nao encontrado");
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
