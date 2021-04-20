using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;
using RedesSockets.Dominio.Usuarios;
using System;
using System.Windows.Forms;

namespace RedesSockets
{
    public partial class aplicacao : Form
    {
        private Cliente _clienteTCP;
        private Cliente _clienteUDP;
        private UsuarioService UsuarioService;
        private MensagemService MensagemService;
        private Usuario Usuario;

        public aplicacao()
        {
            InitializeComponent();
            this.Usuario = new Usuario("4123", "rsybt");
            this._clienteTCP = ClienteTCP.getInstance();
            this._clienteUDP = ClienteUDP.getInstance();
            this.UsuarioService = new UsuarioService();
            this.MensagemService = new MensagemService();
        }

        private void listarUsuariosTimmer_Tick(object sender, EventArgs e)
        {
            try
            {
                this._clienteTCP.Conectar("larc.inf.furb.br", 1012);
                this.UsuarioService.listarUsuarios(this._clienteTCP, this.Usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enviarMensagemButton_Click(object sender, EventArgs e)
        {
            var textoMensagem = mensagemTextBox.Text;
            mensagemTextBox.Clear();
            listaMensagensTextBox.AppendText(textoMensagem);
            listaMensagensTextBox.AppendText(Environment.NewLine);

            try
            {
                this._clienteUDP.Conectar("larc.inf.furb.br", 1011);
                var usuarioDestino = new Usuario("1416");
                var mensagem = new Mensagem(textoMensagem);
                this.MensagemService.enviarMensagem(this._clienteUDP, this.Usuario, usuarioDestino, mensagem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void receberMensagemButton_Click(object sender, EventArgs e)
        {
            try
            {
                this._clienteTCP.Conectar("larc.inf.furb.br", 1012);
                var mensagem = this.MensagemService.retornarMensagem(this._clienteTCP, this.Usuario);
                listaMensagensTextBox.AppendText(mensagem.getConteudo());
                listaMensagensTextBox.AppendText(Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
