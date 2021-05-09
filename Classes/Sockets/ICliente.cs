using RedesSockets.Dominio.Mensagens;

namespace RedesSockets.Classes.Sockets
{
    public interface ICliente
    {
        bool Enviar(Mensagem mensagem);
        Mensagem Receber();
        void Conectar(string ipString, int porta);
        void Desconectar();
    }
}
