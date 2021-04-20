using RedesSockets.Dominio.Mensagens;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RedesSockets.Classes.Sockets
{
    public class ClienteUDP : Cliente
    {
        private Socket Socket;
        private static ClienteUDP _instance;

        public static ClienteUDP getInstance()
        {
            if (_instance == null)
            {
                _instance = new ClienteUDP();
            }
            return _instance;
        }

        public ClienteUDP()
        {
            this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
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
