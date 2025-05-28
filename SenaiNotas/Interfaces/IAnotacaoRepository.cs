using SenaiNotas.DTO;
using SenaiNotas.Models;

namespace SenaiNotas.Interfaces
{
    public interface IAnotacaoRepository
    {
        Task<Nota> CadastrarNota(CadastroAnotacaoDto anotacao);

        Task<Nota> ArquivarAnotacao(int IdNota);

        Task<List<ListarNotaDTO>> ListarAnotacoesPorUserId(int idUsuario);

        Task DeletaNota(int IdNota);

        Task AtualizarNota(int IdNota, AtualizarNotaDTO nota);

    }
}
