using RedesSockets.Dominio.Mensagens;

namespace RedesSockets.Classes.Comandos
{
    /*
     * A ideia é utilizar o Command Pattern (http://www.macoratti.net/13/03/net_cmd.htm)
     * Cada comando executa uma tarefa de forma única
     */
    public interface IComando
    {
        Mensagem Executar();
    }
}
