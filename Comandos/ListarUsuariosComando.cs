using RedesSockets.Sockets;
using RedesSockets.Mensagens;
using RedesSockets.Usuarios;
using System.Net.Sockets;

namespace RedesSockets.Comandos
{
    public class ListarUsuariosComando : IComando
    {
        private readonly Usuario Usuario;
        // nesse ponto foi utilizado a interface, ou seja, esse comando pode ser executado por qualquer cliente
        private readonly ICliente Cliente;

        private const string ConteudoComando = "GET USERS {0}:{1}";

        public ListarUsuariosComando(ICliente cliente, Usuario usuario)
        {
            Usuario = usuario;
            Cliente = cliente;
        }
        public Mensagem Executar()
        {
            var conteudo = string.Format(ConteudoComando, Usuario.UserId, Usuario.UserPass);

            if(!Cliente.Enviar(new Mensagem(conteudo)))
            {
                throw new SocketException();
            }
            return Cliente.Receber();
        }
    }
}
