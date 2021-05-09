using RedesSockets.Dominio.Mensagens;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RedesSockets.Classes.Sockets
{
    public class ClienteTCP : ICliente
    {
        private readonly Socket Socket;

        public ClienteTCP()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
            var conteudo = new byte[1024];
            var bytesRecebidos = Socket.Receive(conteudo);
            return new Mensagem(Encoding.ASCII.GetString(conteudo, 0, bytesRecebidos));
        }

        public bool Enviar(Mensagem mensagem)
        {
            return Socket.Send(mensagem.GetBytesConteudo()) > 0;
        }
    }
}
