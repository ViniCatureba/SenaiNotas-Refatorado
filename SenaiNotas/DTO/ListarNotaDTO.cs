namespace SenaiNotas.DTO
{
    public class ListarNotaDTO
    {
        public string? Titulo { get; set; }

        public string? Conteudo { get; set; }

        public bool? Arquivado { get; set; }
        public string? Imagem { get; set; }
        public DateTime? UltimoRefresh { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
