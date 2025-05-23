using Microsoft.AspNetCore.Identity;
using SenaiNotas.Models;

namespace SenaiNotas.Services
{
    public class PasswordService
    {
        //Passwordhasher
        private readonly PasswordHasher<Usuario> _hasher = new();

        public string HashPassword (Usuario usuario)
        {
            return _hasher.HashPassword(usuario, usuario.Senha);
        }


        //Verificar hash
        public bool VerificarSenha(Usuario usuario, string senha)
        {
            var resultado = _hasher.VerifyHashedPassword(usuario, usuario.Senha, senha);
            if (resultado == PasswordVerificationResult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
