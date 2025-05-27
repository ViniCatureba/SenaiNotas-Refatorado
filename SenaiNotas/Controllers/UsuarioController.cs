using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Notas.DTO;
using SenaiNotas.DTO;
using SenaiNotas.Exceptions;
using SenaiNotas.Interfaces;
using SenaiNotas.Services;

namespace SenaiNotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //inserir a interface
        private IUsuarioRepository _usuarioRepository;

        //instancia o passwordService
        private PasswordService passwordService = new PasswordService();

        //Controller
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }



        //Cadastrar usuario
        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO)
        {
            try
            {
                await _usuarioRepository.CadastrarUsuario(usuarioDTO);
                return Ok("Usuario cadastrado com sucesso");
            }
            catch (UsuarioJaExisteException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("AlterarSenhaUsuario")]
        public async Task<IActionResult> AlterarSenhaUsuario(AlterarSenhaDTO alterarSenhaDTO)
        {
            try
            {
                await _usuarioRepository.AlterarSenhaUsuario(alterarSenhaDTO);
                return Ok("Senha alterada com sucesso");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor: " + ex.Message);
            }
        }

        [HttpGet("ListarUsuario/{id}")]
        public async Task<IActionResult> ListarUsuario(int id)
        {
            return Ok(await _usuarioRepository.ListarUsuario(id));
        }
        //login deve retornar token e user

        //return Ok(new{
            //token ,
            //usuario
        }
    }

