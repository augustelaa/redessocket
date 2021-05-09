using System;
using System.Text;

namespace RedesSockets.Dominio.Mensagens
{
    public class Mensagem
    {
        private readonly string Conteudo;
        public Mensagem(string conteudo)
        {
            if (conteudo.Length == 0)
            {
                throw new ArgumentNullException("Conteudo inválido.");
            }

            Conteudo = conteudo;
        }
        public byte[] GetBytesConteudo()
        {
            return Encoding.ASCII.GetBytes(Conteudo);
        }
        public string GetConteudo()
        {
            return Conteudo;
        }
    }
}
