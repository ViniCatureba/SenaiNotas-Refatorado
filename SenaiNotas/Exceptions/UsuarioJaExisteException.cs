namespace SenaiNotas.Exceptions
{
    public class UsuarioJaExisteException : Exception
    {
        public UsuarioJaExisteException(string mensagem)
            : base(mensagem)
        {
        }
    }
}