using SenaiNotas.Context;
using SenaiNotas.DTO;
using SenaiNotas.Interfaces;
using SenaiNotas.Models;

namespace SenaiNotas.Repositories
{
    public class NotaRepository : IAnotacaoRepository
    {
        private readonly ITagRepository _tagRepository;

        private readonly SenaiNotesContext _context;

        public NotaRepository(SenaiNotesContext context, ITagRepository tagRepository)
        {
            context = _context;
            _tagRepository = tagRepository;
        }


        public async Task ArquivarAnotacao(int id)
        {
            //encontrar a anotacao
            var anotacao = _context.Notas.Find(id);

            if (anotacao is null) { throw new ArgumentException("Nota nao encontrado"); };


            // 2- Trocar o status de arquivada
            anotacao.Arquivado = !anotacao.Arquivado;

            await _context.SaveChangesAsync();

        }

        public Task AtualizarNota(int IdNota, Nota nota)
        {
            throw new NotImplementedException();
        }

        public async Task CadastrarNota(CadastroAnotacaoDto nota)
        {
            //1 - Percorrer a lista de tags
            //1.1 - Essa tag ja existe??
            // 1.2 Essa tag existe, pegar o id dela
            //1.2 - Essa tag não existe, criar uma nova tag, e pegar o id dela
            List<int> idTags = new List<int>();
            throw new NotImplementedException();
            //foreach (var item in anotacao.Tags)
            //{

            //    var tag = _tagRepository.BuscarPorUsuarioeId(anotacao.IdUsuario, item);

            //    if (tag is null)
            //    {

            //        tag = new Tag
            //        {
            //            Nome = item,
            //            Id = anotacao.IdUsuario
            //        };

            //        _context.Add(tag);
            //        _context.SaveChanges();
            //    }
            //    idTags.Add(tag.IdTag);
            //}
        }

        public Task DeletaNota(int IdNota)
        {
            throw new NotImplementedException();
        }

        public Task EditarNota(int IdNota)
        {
            throw new NotImplementedException();
        }

        public Task<ListarNotaDTO> ListarAnotacoes(int IdNota)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAnotacaoRepository.ArquivarAnotacao(int IdNota)
        {
            throw new NotImplementedException();
        }
    }
}