using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;
using RedesSockets.Dominio.Usuarios;
using System.Net.Sockets;

namespace RedesSockets.Classes.Comandos
{
    public class EnviarMensagemComando : Comando
    {
        private Usuario Usuario; 
        private Usuario UsuarioDestino;
        private Mensagem Mensagem;
        private const string ConteudoComando = "SEND MESSAGE {0}:{1}:{2}:{3}";

        public EnviarMensagemComando(Cliente cliente, Usuario usuario, Usuario usuarioDestino, Mensagem mensagem) : base(cliente)
        {
            this.Usuario = usuario;
            this.UsuarioDestino = usuarioDestino;
            this.Mensagem = mensagem;
        }
        public override Mensagem Executar()
        {
            var conteudo = string.Format(ConteudoComando, this.Usuario.UserId, this.Usuario.UserPass, this.UsuarioDestino.UserId, this.Mensagem);
            if (!this.Cliente.Enviar(new Mensagem(conteudo)))
            {
                throw new SocketException();
            }
            return this.Cliente.Receber();
        }
    }
}
