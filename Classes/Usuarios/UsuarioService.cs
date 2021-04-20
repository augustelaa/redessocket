using RedesSockets.Classes.Comandos;
using RedesSockets.Classes.Sockets;
using System.Collections.Generic;

namespace RedesSockets.Dominio.Usuarios
{
    public class UsuarioService
    {
        private static UsuarioService _instance;

        public static UsuarioService getInstance()
        {
            if (_instance == null)
            {
                _instance = new UsuarioService();
            }
            return _instance;
        }
        public List<Usuario> listarUsuarios(Usuario usuario)
        {
            var usuarios = new List<Usuario>();

            var cliente = ClienteTCP.getInstance();
            cliente.Conectar("larc.inf.furb.br", 1012);
            var listarUsuarios = new ListarUsuariosComando(cliente, usuario);
            var retorno = listarUsuarios.Executar();

            return usuarios;
        }
    }
}
