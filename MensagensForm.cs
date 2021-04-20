using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;
using RedesSockets.Dominio.Usuarios;
using System;
using System.Windows.Forms;

namespace RedesSockets
{
    public partial class aplicacao : Form
    {
        private Cliente ClienteTCP;
        private Cliente ClienteUDP;
        private UsuarioService UsuarioService;
        private MensagemService MensagemService;
        private Usuario Usuario;

        public aplicacao()
        {
            InitializeComponent();
            this.Usuario = new Usuario("4123", "rsybt");
            this.ClienteTCP = new ClienteTCP();
            this.ClienteUDP = new ClienteUDP();
            this.UsuarioService = new UsuarioService();
            this.MensagemService = new MensagemService();
        }

        private void listarUsuariosTimmer_Tick(object sender, EventArgs e)
        {
            this.ClienteTCP.Conectar("larc.inf.furb.br", 1012);
            this.UsuarioService.listarUsuarios(this.ClienteTCP, this.Usuario);
        }

        private void enviarMensagemButton_Click(object sender, EventArgs e)
        {
            var textoMensagem = mensagemTextBox.Text;
            mensagemTextBox.Clear();
            listaMensagensTextBox.AppendText(textoMensagem);
            listaMensagensTextBox.AppendText(Environment.NewLine);

            this.ClienteUDP.Conectar("larc.inf.furb.br", 1011);
            var usuarioDestino = new Usuario("1416");
            var mensagem = new Mensagem(textoMensagem);
            this.MensagemService.enviarMensagem(this.ClienteUDP, this.Usuario, usuarioDestino, mensagem);
        }

        private void receberMensagemButton_Click(object sender, EventArgs e)
        {
            var mensagem = this.MensagemService.retornarMensagem(this.ClienteTCP, this.Usuario);
            listaMensagensTextBox.AppendText(mensagem.getConteudo());
            listaMensagensTextBox.AppendText(Environment.NewLine);
        }
    }
}
