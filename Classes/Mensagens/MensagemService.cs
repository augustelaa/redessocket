using RedesSockets.Classes.Comandos;
using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Usuarios;

namespace RedesSockets.Dominio.Mensagens
{
    public class MensagemService
    {
        // Singleton
        private static MensagemService _instance;

        public static MensagemService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MensagemService();
            }
            return _instance;
        }
        public Mensagem RetornarMensagem(Usuario usuario)
        {
            var cliente = new ClienteTCP();
            try
            {
                cliente.Conectar("larc.inf.furb.br", 1012);
                var retorno = new RetornarMensagemComando(cliente, usuario).Executar();
                if (retorno.GetConteudo().Trim().Equals(":")) // quando vier apenas ":" significa que não há msg
                {
                    return new Mensagem("Sem mensagens\r\n");
                }
                return retorno;
            }
            finally
            {
                cliente.Desconectar();
            }
        }
        public bool EnviarMensagem(Usuario usuario, Usuario usuarioDestino, Mensagem mensagem)
        {
            var cliente = new ClienteUDP();
            try
            {
                cliente.Conectar("larc.inf.furb.br", 1011);
                new EnviarMensagemComando(cliente, usuario, usuarioDestino, mensagem).Executar();
                return true;
            }
            finally
            {
                cliente.Desconectar();
            }
        }
    }
}
