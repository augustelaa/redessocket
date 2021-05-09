using System;

namespace RedesSockets.Usuarios
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
        /**
         * O componente ListBox aceita objects, para que o object fique com uma descrição
         * mais humana, iremos implementar um ToString sobscrevendo o ToString de object
         * TIP: TODA CLASSE (INCLUSIVE A USUARIO) HERDA DE OBJECT IMPLICITAMENTE
         */
        public override string ToString()
        {
            return String.Format("{0}:{1}", UserId, UserName);
        }
    }
}
