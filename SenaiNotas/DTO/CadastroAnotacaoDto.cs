namespace SenaiNotas.DTO
{
    public class CadastroAnotacaoDto
    {
        public string? Titulo { get; set; } = null!;

        public string? Conteudo { get; set; } = null;

        public DateTime? UltimoRefresh { get; set; }

        public DateTime? DataCriacao { get; set; }

        public string? Imagem { get; set; }

        public bool? AnotacaoArquivada { get; set; }

        public int IdUsuario { get; set; }

        public IFormFile? ArquivoImagem { get; set; }

        public List<string> Tags { get; set; }
    }
}
