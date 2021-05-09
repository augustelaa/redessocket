﻿using RedesSockets.Sockets;
using RedesSockets.Mensagens;
using RedesSockets.Usuarios;
using System.Net.Sockets;

namespace RedesSockets.Comandos
{
    public class RetornarMensagemComando : IComando
    {
        private readonly Usuario Usuario;
        // nesse ponto foi utilizado a interface, ou seja, esse comando pode ser executado por qualquer cliente
        private readonly ICliente Cliente;

        private const string ConteudoComando = "GET MESSAGE {0}:{1}";

        public RetornarMensagemComando(ICliente cliente, Usuario usuario)
        {
            Usuario = usuario;
            Cliente = cliente;
        }
        // [EXEMPLO ENTRADA]
        // GET MESSAGE <userid>:<passwd>
        // [EXEMPLO SAIDA]
        // <userid>:<msg>
        public Mensagem Executar()
        {
            var conteudo = string.Format(ConteudoComando, Usuario.UserId, Usuario.UserPass);

            if (!Cliente.Enviar(new Mensagem(conteudo)))
            {
                throw new SocketException();
            }
            return Cliente.Receber();
        }
    }
}
