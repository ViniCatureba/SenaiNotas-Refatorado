using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotas.DTO;
using SenaiNotas.Interfaces;
using SenaiNotas.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SenaiNotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnotacaoController : ControllerBase
    {
        private readonly IAnotacaoRepository _repository;

        public AnotacaoController(IAnotacaoRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("CadastrarNota")]
        public async Task<IActionResult> CadastrarNota(CadastroAnotacaoDto anotacaoDto)
        {
            if (anotacaoDto.ArquivoImagem != null)
            {
                //Extra verificar se o arquivo é uma imagem
                // 1 - Criar uma variavel - Pasta de destino
                var pastaDeDestino = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                //2 - Salvar o arquivo

                //EXTRA - Criar um nome personalizado para o arquivo
                var nomeArquivo = anotacaoDto.ArquivoImagem.FileName;

                var caminhoCompleto = Path.Combine(pastaDeDestino, nomeArquivo);

                //controlar memory leek
                using (var stream = new FileStream(caminhoCompleto, FileMode.Create)) //open - le arqvuido
                {
                    anotacaoDto.ArquivoImagem.CopyTo(stream);
                }

                //3- guardar o arquivo no db
                anotacaoDto.Imagem = nomeArquivo;
            }
            _repository.CadastrarNota(anotacaoDto);
            return Created();
        }


        [HttpPost("ArquivarAnotacao/{IdNota}")]

        [SwaggerOperation(
            Summary = "Arquiva uma anotação",
            Description = "Este endpoint arquiva uma anotação existente com base no ID fornecido.",
            OperationId = "ArquivarAnotacao"
        )]

        public async Task<IActionResult> ArquivarAnotacao(int IdNota)
        {
            var nota = _repository.ArquivarAnotacao(IdNota);
            if (nota != null) { return NotFound(); }
            return Ok(nota);
        }

        [HttpGet("ListarAnotacoesPorUserId/{idNota}")]


        public async Task<IActionResult> ListarAnotacoesPorUserId(int idNota)
        {
            var nota = _repository.ListarAnotacoesPorUserId(idNota);
            return Ok(nota);
        }

        [HttpDelete("DeletarNota/{idNota}")]
        public async Task<IActionResult> DeletarNota(int idNota)
        {
            var nota = _repository.DeletaNota(idNota);
            if (nota == null) return NotFound();

            return Ok(nota);

        }

        [HttpPut("AtualizarNota/{notaId}")]

        public async Task<IActionResult> AtualizarNota(int notaId, AtualizarNotaDTO nota)
        {
            {
                var novaNota = _repository.AtualizarNota(notaId, nota);
                if (novaNota == null) return NotFound();

                return Ok(novaNota);

            }
        }
    }
}