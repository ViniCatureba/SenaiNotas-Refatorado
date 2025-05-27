using SenaiNotas.Models;

namespace SenaiNotas.Interfaces
{
    public interface ITagRepository
    {
        // Cria uma nova tag
        Task CriarTag(Tag? tag);

        // Retorna todas as tags
        Task<List<Tag>>? ListarTodas(int idUsuario);

        // Busca uma tag pelo ID
        Task<Tag>? BuscarPorId(int idUsuario);

        Tag BuscarPorUsuarioeId(int id, string nome);

        Task AtualizarTag(int id, Tag tag);

        Task DeleatarTag(int id);
    }
}