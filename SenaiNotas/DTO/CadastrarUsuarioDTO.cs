using System.ComponentModel.DataAnnotations;

namespace Senai_Notas.DTO
{
    public class CadastrarUsuarioDTO
    {

        public string Nome { get; set; } = null!;


        public string Email { get; set; } = null!;


        public string Senha { get; set; } = null!;

    }
}