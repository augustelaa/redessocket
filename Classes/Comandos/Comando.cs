using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;

namespace RedesSockets.Classes.Comandos
{
    public abstract class Comando
    {
        protected Cliente Cliente;
        public Comando(Cliente cliente)
        {
            this.Cliente = cliente;
        }

        public abstract Mensagem Executar();
    }
}
