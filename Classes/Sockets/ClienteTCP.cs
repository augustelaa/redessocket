using RedesSockets.Dominio.Mensagens;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RedesSockets.Classes.Sockets
{
    public class ClienteTCP : Cliente
    {
        private Socket Socket;
        private static ClienteTCP _instance;
        
        public static ClienteTCP getInstance()
        {
            if (_instance == null)
            {
                _instance = new ClienteTCP();
            }
            return _instance;
        }

        public ClienteTCP()
        {
            this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Conectar(string hostName, int porta)
        {
            if (this.Socket.Connected)
            {
                return;
            }
            IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            this.Socket.Connect(ipAddress, porta);
        }

        public void Desconectar()
        {
            this.Socket.Shutdown(SocketShutdown.Both);
            this.Socket.Close();
        }

        public Mensagem Receber()
        {
            var conteudo = new byte[1024];
            var bytesRecebidos = this.Socket.Receive(conteudo);
            return new Mensagem(Encoding.ASCII.GetString(conteudo, 0, bytesRecebidos));
        }

        public bool Enviar(Mensagem mensagem)
        {
            return this.Socket.Send(mensagem.getBytesConteudo()) > 0;
        }
    }
}
