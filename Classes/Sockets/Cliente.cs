using RedesSockets.Dominio.Mensagens;
using System.Net;
using System.Net.Sockets;

namespace RedesSockets.Classes.Sockets
{
    public interface Cliente
    {
        bool Enviar(Mensagem mensagem);
        Mensagem Receber();
        void Conectar(string ipString, int porta);
        void Desconectar();
    }
}
