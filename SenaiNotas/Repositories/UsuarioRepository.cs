using Microsoft.JSInterop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Senai_Notas.DTO;
using SenaiNotas.Context;
using SenaiNotas.DTO;
using SenaiNotas.Interfaces;
using SenaiNotas.Models;
using SenaiNotas.Services;
using SenaiNotas.ViewModel;
using SenaiNotas.Exceptions;

namespace SenaiNotas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository

    {
        private readonly SenaiNotesContext _context;


        public UsuarioRepository(SenaiNotesContext context)
        {
            _context = context;
        }
        public async Task AlterarSenhaUsuario(AlterarSenhaDTO alterarSenhaDTO)
        {
            var passwordService = new PasswordService();

            var encontrarUser = await _context.Usuarios.FirstOrDefaultAsync(c => c.IdUsuario == alterarSenhaDTO.IdUsuario);
            if (encontrarUser == null) { throw new ArgumentException("Cliente nao encontrado"); }

            var verificarHash = passwordService.VerificarSenha(encontrarUser, alterarSenhaDTO.Senha);
            if (verificarHash == false)
            {
                throw new ArgumentException("Senha incorreta");
            }
            var novaSenha = new Usuario()
            {
                IdUsuario = alterarSenhaDTO.IdUsuario,
                Senha = alterarSenhaDTO.Senha

            };
            novaSenha.Senha = passwordService.HashPassword(novaSenha);

            encontrarUser.Senha = novaSenha.Senha;
            await _context.SaveChangesAsync(); //await aqui?
            


        }

        //Criar usuario
        public async Task CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO)
        {
            var passwordService = new PasswordService();

            var usuarioExistente = await _context.Usuarios.AnyAsync(u => u.Email == usuarioDTO.Email);

            if (usuarioExistente)
            {
                throw new UsuarioJaExisteException("Já existe um usuário com este email.");
            }

            var usuario = new Usuario()
            {
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha
            };
            usuario.Senha = passwordService.HashPassword(usuario);
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuaruio(int idUsuario)
        {
            var encontrarUsuario = _context.Usuarios.FirstOrDefaultAsync(c => c.IdUsuario == idUsuario);

            if (encontrarUsuario == null) { throw new ArgumentException("Usuario nao encontrado"); }
            _context.Usuarios.Remove(await encontrarUsuario);
            await _context.SaveChangesAsync();
        }

        public async Task<ListarUsuarioViewModel> ListarUsuario(int idUsuario)
        {
            var encontrarUsuario = await _context.Usuarios.FirstOrDefaultAsync(c => c.IdUsuario == idUsuario);
            
            if (encontrarUsuario == null) { throw new ArgumentException("Usuario nao encontrado"); }

            return new ListarUsuarioViewModel
            {
                Nome = encontrarUsuario.Nome,
                Email = encontrarUsuario.Email
            };

        }

        public async Task<bool> Login(LoginDto loginDTO)
        {
            var emailEncontrado = _context.Usuarios.FirstOrDefaultAsync(c => c.Email == loginDTO.Email);
            if (emailEncontrado == null) { throw new ArgumentException("E-mail ou senha invalidos"); }

            var passwordService = new PasswordService();
            var verificarHash = passwordService.VerificarSenha(await emailEncontrado, loginDTO.Senha); //sem await)?
            if (verificarHash == true) return true;
            return false;
            //TODO: Implementar JWT


        }
    }
}
