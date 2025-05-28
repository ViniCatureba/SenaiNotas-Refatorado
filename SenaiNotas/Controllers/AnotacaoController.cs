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
            try
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
                await _repository.CadastrarNota(anotacaoDto);
                return Created();
            }
            catch (ArgumentException ex)  // Exemplo: se lançar essa exceção no repositório
            {
                // Erro conhecido, retorna 400 (Bad Request) com a mensagem
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Erro inesperado, pode logar aqui e retornar 500 (Internal Server Error)
                // Exemplo: _logger.LogError(ex, "Erro ao cadastrar nota");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro interno no servidor." });
            }
        }
        


        [HttpPost("ArquivarAnotacao/{IdNota}")]

        [SwaggerOperation(
            Summary = "Arquiva uma anotação",
            Description = "Este endpoint arquiva uma anotação existente com base no ID fornecido.",
            OperationId = "ArquivarAnotacao"
        )]

        public async Task<IActionResult> ArquivarAnotacao(int IdNota)
        {
            var nota = await _repository.ArquivarAnotacao(IdNota);
            if (nota != null) { return NotFound(); }
            return Ok(nota);
        }

        [HttpGet("ListarAnotacoesPorUserId/{idUsuario}")]


        public async Task<IActionResult> ListarAnotacoesPorUserId(int idUsuario)
        {
            var nota = await _repository.ListarAnotacoesPorUserId(idUsuario);
            return Ok(nota);
        }

        [HttpDelete("DeletarNota/{idNota}")]
        public async Task<IActionResult> DeletarNota(int idNota)
        {
            try
            {
                await _repository.DeletaNota(idNota);
                return Ok();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPut("AtualizarNota/{notaId}")]

        public async Task<IActionResult> AtualizarNota(int notaId, AtualizarNotaDTO nota)
        {
            
                try
                {
                    await _repository.AtualizarNota(notaId, nota);
                    return NoContent();
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }
    }
}