using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotas.DTO;
using SenaiNotas.Interfaces;

namespace SenaiNotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet("ListarTodo/{idUsuario}")]

        public async Task<IActionResult> ListarTodos(int idUsuario)
        {
            var tags = await _tagRepository.ListarTodas(idUsuario);
            return Ok(tags);   
        }

        [HttpGet("BuscarPorId/{IdTag}")]
        public async Task<IActionResult> BuscarPorId(int idTag)
        {
            var tag = await _tagRepository.BuscarPorId(idTag);
            return Ok(tag);
        }

        [HttpGet("usuario/{idUsuario}/nome/{nome}")]
        public async Task<IActionResult> BuscarPorIdENome(int idTag, string nome)
        {
            var tag = await _tagRepository.BuscarPorUsuarioeId(idTag, nome);
            return Ok(tag);
        }

        [HttpPost("CriarTag")]
        public async Task<IActionResult> CriarTag(CadastrarTagDTO tag)
        {
            try
            {
                await _tagRepository.CriarTag(tag);
                return StatusCode(201);
            }     
            catch (ArgumentException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao criar a tag.", erro = ex.Message });
            }
        }

        [HttpDelete("DeletarTag/{idTag}")]
        public async Task<IActionResult> DeletarTag(int idTag)
        {
            try
            {
                await _tagRepository.DeleatarTag(idTag);
                return StatusCode(201);
            }
            catch (ArgumentException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao criar a tag.", erro = ex.Message });
            }

        }

        [HttpPost("atualizarTag/{idTag}")]
        public async Task<IActionResult> AtualizarTag(int idTag, CadastrarTagDTO tagDTO)
        {
            try
            {
                await _tagRepository.AtualizarTag(idTag, tagDTO);
                return StatusCode(201);
            }
            catch (ArgumentException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao criar a tag.", erro = ex.Message });
            }
        }


    }
}
