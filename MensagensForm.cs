using RedesSockets.Classes.Sockets;
using RedesSockets.Dominio.Mensagens;
using RedesSockets.Dominio.Usuarios;
using System;
using System.Windows.Forms;

namespace RedesSockets
{
    public partial class Aplicacao : Form
    {
        private readonly UsuarioService _usuarioService;
        private readonly MensagemService _mensagemService;
        private readonly Usuario Usuario;

        public Aplicacao()
        {
            InitializeComponent();
            Usuario = new Usuario("8722", "hieef", "Augusto");
            ListaUsuariosListBox.Items.Add(Usuario);

            _usuarioService = UsuarioService.GetInstance();
            _mensagemService = MensagemService.GetInstance();
        }

        private void ListarUsuariosTimmer_Tick(object sender, EventArgs e)
        {
            try
            {
                ListaUsuariosListBox.Items.Clear();
                ListaUsuariosListBox.Items.Add(Usuario);

                _usuarioService.ListarUsuarios(Usuario).ForEach(u =>
                {
                    if (u.UserId == Usuario.UserId) return;
                    ListaUsuariosListBox.Items.Add(u);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviarMensagemButton_Click(object sender, EventArgs e)
        {
            var textoMensagem = MensagemTextBox.Text;

            try
            {
                if (ListaUsuariosListBox.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um usuário!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Usuario usuarioDestino = (Usuario)ListaUsuariosListBox.SelectedItem;
                var mensagem = new Mensagem(textoMensagem);
                if (_mensagemService.EnviarMensagem(Usuario, usuarioDestino, mensagem))
                {
                    MensagemTextBox.Clear();
                    ListaMensagensTextBox.AppendText(String.Format(">>>{0}:{1}", usuarioDestino.UserId, textoMensagem));
                    ListaMensagensTextBox.AppendText(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceberMensagemButton_Click(object sender, EventArgs e)
        {
            try
            {
                var mensagem = _mensagemService.RetornarMensagem(Usuario);
                ListaMensagensTextBox.AppendText(String.Format("<<<{0}", mensagem.GetConteudo()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
