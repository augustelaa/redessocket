using System;
using System.Collections.Generic;
using System.Text;

namespace RedesSockets.Dominio.Usuarios
{
    public class Usuario
    {
        public string UserId { get; }
        public string UserPass { get; }

        public Usuario(string userId, string userPass)
        {
            if (userId.Length == 0 || userPass.Length == 0)
            {
                throw new ArgumentNullException("Usuario inválido.");
            }
            this.UserId = userId;
            this.UserPass = userPass;
        }
        public Usuario(string userId)
        {
            if (userId.Length == 0)
            {
                throw new ArgumentNullException("Usuario inválido.");
            }
            this.UserId = userId;
        }
    }
}
