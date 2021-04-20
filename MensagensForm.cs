using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;
using RedesSockets.Dominio.Usuarios;
using System;
using System.Windows.Forms;

namespace RedesSockets
{
    public partial class aplicacao : Form
    {
        private UsuarioService _usuarioService;
        private MensagemService _mensagemService;
        private Usuario Usuario;

        public aplicacao()
        {
            InitializeComponent();
            this.Usuario = new Usuario("4123", "rsybt");

            this._usuarioService = UsuarioService.getInstance();
            this._mensagemService = MensagemService.getInstance();
        }

        private void listarUsuariosTimmer_Tick(object sender, EventArgs e)
        {
            try
            {
                this._usuarioService.listarUsuarios(this.Usuario);
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
                var usuarioDestino = new Usuario("1416");
                var mensagem = new Mensagem(textoMensagem);
                this._mensagemService.enviarMensagem(this.Usuario, usuarioDestino, mensagem);
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
                var mensagem = this._mensagemService.retornarMensagem(this.Usuario);
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
