using System.ComponentModel.DataAnnotations;

namespace Senai_Notas.DTO
{
    public class CadastrarUsuarioDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

    }
}