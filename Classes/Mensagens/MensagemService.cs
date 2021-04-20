using RedesSockets.Classes.Comandos;
using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedesSockets.Dominio.Mensagens
{
    public class MensagemService
    {
        private static MensagemService _instance;

        public static MensagemService getInstance()
        {
            if (_instance == null)
            {
                _instance = new MensagemService();
            }
            return _instance;
        }
        public Mensagem retornarMensagem(Usuario usuario)
        {
            var cliente = ClienteTCP.getInstance();
            cliente.Conectar("larc.inf.furb.br", 1012);
            var retornarMensagem = new RetornarMensagemComando(cliente, usuario);
            return retornarMensagem.Executar();
        }
        public Mensagem enviarMensagem(Usuario usuario, Usuario usuarioDestino, Mensagem mensagem)
        {
            var cliente = ClienteUDP.getInstance();
            cliente.Conectar("larc.inf.furb.br", 1011);
            var enviarMensagem = new EnviarMensagemComando(cliente, usuario, usuarioDestino, mensagem);
            return enviarMensagem.Executar();
        }
    }
}
