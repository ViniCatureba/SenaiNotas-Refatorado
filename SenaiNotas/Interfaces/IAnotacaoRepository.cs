using SenaiNotas.DTO;
using SenaiNotas.Models;

namespace SenaiNotas.Interfaces
{
    public interface IAnotacaoRepository
    {
        Task CadastrarNota(CadastroAnotacaoDto nota);

        Task<bool> ArquivarAnotacao(int IdNota);

        Task<ListarNotaDTO> ListarAnotacoes(int IdNota);

        Task EditarNota(int IdNota);

        Task Deletar(int IdNota);

        Task AtualizarNota(int IdNota, Nota nota);

    }
}
