using Senai_Notas.DTO;
using SenaiNotas.DTO;
using SenaiNotas.Models;
using SenaiNotas.ViewModel;


namespace SenaiNotas.Interfaces
{
    public interface IUsuarioRepository
    {

        //Cadastra usuario - Email, senha e nome (DTO)
        Task CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO);

        //Altera usuario - Email, senha e nome (DTO)
        Task AlterarSenhaUsuario(AlterarSenhaDTO alterarSenhaDTO);        

        Task DeletarUsuaruio(int idUsuario);

        Task<ListarUsuarioViewModel> ListarUsuario(int idUsuario);

        Task<ListarUsuarioViewModel> Login(LoginDto loginDTO);
    }
}
