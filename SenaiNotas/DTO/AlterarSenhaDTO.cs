using System.ComponentModel.DataAnnotations;

namespace SenaiNotas.DTO
{
    public class AlterarSenhaDTO
    {
        
        public int IdUsuario { get; set; }

        
        public string Senha { get; set; }

       
        public string NovaSenha { get; set; }
    }
}
