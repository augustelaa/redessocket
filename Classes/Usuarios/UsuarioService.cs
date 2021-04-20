using RedesSockets.Classes.Comandos;
using RedesSockets.Classes.Sockets;
using System.Collections.Generic;

namespace RedesSockets.Dominio.Usuarios
{
    public class UsuarioService
    {
        public List<Usuario> listarUsuarios(Cliente cliente, Usuario usuario)
        {
            var usuarios = new List<Usuario>();

            var listarUsuarios = new ListarUsuariosComando(cliente, usuario);
            var retorno = listarUsuarios.Executar();

            return usuarios;
        }
    }
}
