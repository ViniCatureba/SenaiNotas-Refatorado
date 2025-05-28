using SenaiNotas.DTO;
using SenaiNotas.Models;

namespace SenaiNotas.Interfaces
{
    public interface ITagRepository
    {
        // Cria uma nova tag
        Task CriarTag(CadastrarTagDTO? tag);

        // Retorna todas as tags
        Task<List<Tag>>? ListarTodas(int idUsuario);

        // Busca uma tag pelo ID
        Task<Tag>? BuscarPorId(int idUsuario);

        Task<Tag> BuscarPorUsuarioeId(int id, string nome);

        Task AtualizarTag(int id, CadastrarTagDTO tag);

        Task DeleatarTag(int id);
    }
}