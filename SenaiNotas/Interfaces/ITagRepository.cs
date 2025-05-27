using SenaiNotas.Models;

namespace SenaiNotas.Interfaces
{
    public interface ITagRepository
    {
        // Cria uma nova tag
        void Create(Tag tag);

        // Retorna todas as tags
        IEnumerable<Tag> GetAll();

        // Busca uma tag pelo ID
        Tag? GetById(int id);

        // Atualiza uma tag existente
        void Update(Tag tag);

        // Remove uma tag pelo ID
        void Delete(int id);
    }
}