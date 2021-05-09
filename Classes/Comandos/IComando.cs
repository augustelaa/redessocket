using RedesSockets.Dominio.Mensagens;

namespace RedesSockets.Classes.Comandos
{
    public interface IComando
    {
        public abstract Mensagem Executar();
    }
}
