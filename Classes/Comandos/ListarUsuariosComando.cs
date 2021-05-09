using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;
using RedesSockets.Dominio.Usuarios;
using System.Net.Sockets;

namespace RedesSockets.Classes.Comandos
{
    public class ListarUsuariosComando : IComando
    {
        private readonly Usuario Usuario;
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
