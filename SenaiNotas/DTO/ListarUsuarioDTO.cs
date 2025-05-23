using System.ComponentModel.DataAnnotations;
namespace SenaiNotas.DTO
{
    public interface ListarUsuarioDTO
    {
      
        public string Email { get; set; }

   
        public string Nome { get; set; } 

  
        public bool Tema { get; set; }

  
        public bool Fonte { get; set; }
    }
}
