using RedesSockets.Classes.Comandos;
using RedesSockets.Classes.Sockets;
using System.Collections.Generic;

namespace RedesSockets.Dominio.Usuarios
{
    public class UsuarioService
    {
        private static UsuarioService _instance;

        public static UsuarioService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UsuarioService();
            }
            return _instance;
        }
        public List<Usuario> ListarUsuarios(Usuario usuario)
        {
            var usuarios = new List<Usuario>();
            var cliente = new ClienteTCP();

            try
            {
                cliente.Conectar("larc.inf.furb.br", 1012);
                var retorno = new ListarUsuariosComando(cliente, usuario).Executar();
                var listaString = retorno.GetConteudo().Split(":");

                if (listaString.Length >= 3)
                {

                    var c = 0;
                    var id = "";
                    var name = "";
                    Usuario u;
                    foreach (var item in listaString)
                    {
                        c++;
                        switch (c)
                        {
                            case 1:
                                id = item;
                                break;
                            case 2:
                                name = item;
                                break;
                            case 3:
                                c = 0;
                                u = new Usuario(id);
                                u.UserName = name;
                                usuarios.Add(u);
                                break;
                        }
                    }
                }

            }
            finally
            {
                cliente.Desconectar();
            }
            return usuarios;
        }
    }
}
