﻿using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;
using RedesSockets.Dominio.Usuarios;
using System.Net.Sockets;

namespace RedesSockets.Classes.Comandos
{
    public class EnviarMensagemComando : IComando
    {
        private readonly Usuario Usuario; 
        private readonly Usuario UsuarioDestino;
        private readonly Mensagem Mensagem;
        private readonly ICliente Cliente;

        private const string ConteudoComando = "SEND MESSAGE {0}:{1}:{2}:{3}";

        public EnviarMensagemComando(ICliente cliente, Usuario usuario, Usuario usuarioDestino, 
            Mensagem mensagem)
        {
            Usuario = usuario;
            UsuarioDestino = usuarioDestino;
            Mensagem = mensagem;
            Cliente = cliente;
        }
        public Mensagem Executar()
        {
            var conteudo = string.Format(ConteudoComando, Usuario.UserId, Usuario.UserPass, 
                UsuarioDestino.UserId, Mensagem.GetConteudo());
            
            if (!Cliente.Enviar(new Mensagem(conteudo)))
            {
                throw new SocketException();
            }
            return Cliente.Receber();
        }
    }
}
