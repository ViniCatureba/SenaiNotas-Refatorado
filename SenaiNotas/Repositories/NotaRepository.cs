/*using SenaiNotas.Context;

namespace SenaiNotas.Repositories
{
    public class NotaRepository
    {
        private readonly ItagRepository _tagRepository;

        public NotaRepository(SenaiNotesContext context, ITagRepository tagRepository)
        {
            context = _context;
            _tagRepository = tagRepository;
        }


        public NotaRepository? ArquivarAnotacao(int id)
        {
            //encontrar a anotacao
            var anotacao = _context.Anotacaoes.Find(id);

            if (anotacao is null) return null;


            // 2- Trocar o status de arquivada
            anotacao.AnotacaoArquivada = !anotacao.AnotacaoArquivada;

            _context.SaveChanges();
        }

            public CadastroAnotacaoDto? CadastrarAnotacao(CadastroAnotacaoDto anotacao)
        {
            //1 - Percorrer a lista de tags
            //1.1 - Essa tag ja existe??
            // 1.2 Essa tag existe, pegar o id dela
            //1.2 - Essa tag não existe, criar uma nova tag, e pegar o id dela
            List<int> idTags = new List<int>();

            foreach (var item in anotacao.Tags) {
               
                var tag = _tagRepository.BuscarPorUsuarioeId(anotacao.IdUsuario, item);

                if (tag is null) {
                    //todo: cadastrar a tag
                }
                idTags.Add(tag.IdTag);
            }
    }
}
}
*/