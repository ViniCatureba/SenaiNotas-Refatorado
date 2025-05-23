using System.ComponentModel.DataAnnotations;

namespace SenaiNotas.DTO;
public class LoginDto
{
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
}

