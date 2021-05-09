using RedesSockets.Mensagens;
using System.Net;
using System.Net.Sockets;

namespace RedesSockets.Sockets
{
    public class ClienteUDP : ICliente
    {
        private readonly Socket Socket;

        public ClienteUDP()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public void Conectar(string hostName, int porta)
        {
            if (Socket.Connected)
            {
                return;
            }
            IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            Socket.Connect(ipAddress, porta);
        }

        public void Desconectar()
        {
            if (!Socket.Connected)
            {
                return;
            }
            Socket.Shutdown(SocketShutdown.Both);
            Socket.Close();
        }

        public Mensagem Receber()
        {
            // UDP NÃO RECEBE, JOGOU VOOU
            return null;
        }

        public bool Enviar(Mensagem mensagem)
        {
            return Socket.Send(mensagem.GetBytesConteudo()) > 0;
        }
    }
}
