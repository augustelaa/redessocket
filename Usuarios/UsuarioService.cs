using RedesSockets.Comandos;
using RedesSockets.Sockets;
using System.Collections.Generic;

namespace RedesSockets.Usuarios
{
    public class UsuarioService
    {
        // Singleton
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
                    /**
                     * 
                     * A ideia deste trecho é processar os retornos, cada retorno é composto
                     * por tres pedaços, que são: "id:nome:vitorias:"
                     * Exemplo: 2756:João da Silva:4:1235:José da Silva:0:1243:Manuel da Silva:2:
                     */
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
                                c = 0; // neste ponto recomeçamos
                                u = new Usuario(id); // montamos o obj
                                u.UserName = name;
                                usuarios.Add(u); // adicionamos na lista
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
