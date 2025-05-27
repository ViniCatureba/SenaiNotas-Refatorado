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

        public Task<Tag>? BuscarPorId(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Tag BuscarPorUsuarioeId(int id, string nome)
        {
            throw new NotImplementedException();
        }

        public Task CriarTag(Tag? tag)
        {
            throw new NotImplementedException();
        }

        public Task DeleatarTag(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>>? ListarTodas(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
