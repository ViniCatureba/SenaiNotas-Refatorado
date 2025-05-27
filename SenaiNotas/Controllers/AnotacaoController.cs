using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotas.DTO;

namespace SenaiNotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnotacaoController : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> CadastrarNota(CadastroAnotacaoDto anotacaoDto)
        {
            if (anotacaoDto.ArquivoAnotacao != null)
            {
                //Extra verificar se o arquivo é uma imagem
                // 1 - Criar uma variavel - Pasta de destino
                var pastaDeDestino = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                //2 - Salvar o arquivo

                //EXTRA - Criar um nome personalizado para o arquivo
                var nomeArquivo = anotacaoDto.ArquivoAnotacao.FileName;
                
                var caminhoCompleto = Path.Combine(pastaDeDestino, nomeArquivo);

                //controlar memory leek
                using (var stream = new FileStream(caminhoCompleto, FileMode.Create)) //open - le arqvuido
                {
                    anotacaoDto.ArquivoAnotacao.CopyTo(stream);
                }
                
                //3- guardar o arquivo no db
                anotacaoDto.Imagem = nomeArquivo;
            }
            _repository.CadastrarNota(anotacaoDto);
            return Created();
        }
    }
}
