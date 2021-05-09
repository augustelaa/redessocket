using RedesSockets.Mensagens;

namespace RedesSockets.Sockets
{
    /*
     * A ideia é criar um Strategy (http://www.macoratti.net/19/01/c_strateg1.htm) para o cliente de conexão
     */
    public interface ICliente
    {
        bool Enviar(Mensagem mensagem);
        Mensagem Receber();
        void Conectar(string ipString, int porta);
        void Desconectar();
    }
}
