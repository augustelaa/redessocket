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
        public Mensagem retornarMensagem(Cliente cliente, Usuario usuario)
        {
            var retornarMensagem = new RetornarMensagemComando(cliente, usuario);
            return retornarMensagem.Executar();
        }
        public Mensagem enviarMensagem(Cliente cliente, Usuario usuario, Usuario usuarioDestino, Mensagem mensagem)
        {
            var enviarMensagem = new EnviarMensagemComando(cliente, usuario, usuarioDestino, mensagem);
            return enviarMensagem.Executar();
        }
    }
}
