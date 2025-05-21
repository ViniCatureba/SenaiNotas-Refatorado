using System.ComponentModel.DataAnnotations;

namespace SenaiNotas.DTO
{
    public class AlterarSenhaDTO
    {
        [Required]
        public string Senha { get; set; }

        [Required]
        public string NovaSenha { get; set; }
    }
}
