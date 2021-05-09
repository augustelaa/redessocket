using System;

namespace RedesSockets.Dominio.Usuarios
{
    public class Usuario
    {
        public string UserId { get; }
        public string UserPass { get; }
        public string UserName { get; set; }

        public Usuario(string userId, string userPass)
        {
            if (userId.Length == 0 || userPass.Length == 0)
            {
                throw new ArgumentNullException("Usuario inválido.");
            }
            UserId = userId;
            UserPass = userPass;
        }
        public Usuario(string userId, string userPass, string userName)
        {
            if (userId.Length == 0 || userPass.Length == 0 || userName.Length == 0)
            {
                throw new ArgumentNullException("Usuario inválido.");
            }
            UserId = userId;
            UserPass = userPass;
            UserName = userName;
        }
        public Usuario(string userId)
        {
            if (userId.Length == 0)
            {
                throw new ArgumentNullException("Usuario inválido.");
            }
            UserId = userId;
        }
        public override string ToString()
        {
            return String.Format("{0}:{1}", UserId, UserName);
        }
    }
}
