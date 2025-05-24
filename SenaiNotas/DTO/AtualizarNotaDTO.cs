namespace SenaiNotas.DTO
{
    public class AtualizarNotaDTO
    {
        public string? Titulo { get; set; } = null!;

        public string? Conteudo { get; set; } = null;

        public DateTime? UltimoRefresh { get; set; }

        public string? Imagem { get; set; }
    }
}
