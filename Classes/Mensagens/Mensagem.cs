using System;
using System.Collections.Generic;
using System.Text;

namespace RedesSockets.Dominio.Mensagens
{
    public class Mensagem
    {
        private string Conteudo;
        
        public Mensagem(string conteudo)
        {
            if (conteudo.Length == 0)
            {
                throw new ArgumentNullException("Conteudo inválido.");
            }

            this.Conteudo = conteudo;
        }
        public byte[] getBytesConteudo()
        {
            return Encoding.ASCII.GetBytes(this.Conteudo);
        }
        public string getConteudo()
        {
            return this.Conteudo;
        }
    }
}
