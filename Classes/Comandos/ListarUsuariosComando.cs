using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;
using RedesSockets.Dominio.Usuarios;
using System.Net.Sockets;

namespace RedesSockets.Classes.Comandos
{
    public class ListarUsuariosComando : Comando
    {
        private Usuario Usuario;
        private const string ConteudoComando = "GET USERS {0}:{1}";

        public ListarUsuariosComando(Cliente cliente, Usuario usuario): base(cliente)
        {
            this.Usuario = usuario;
        }
        public override Mensagem Executar()
        {
            var conteudo = string.Format(ConteudoComando, this.Usuario.UserId, this.Usuario.UserPass);
            if(!this.Cliente.Enviar(new Mensagem(conteudo)))
            {
                throw new SocketException();
            }
            return this.Cliente.Receber();
        }
    }
}
