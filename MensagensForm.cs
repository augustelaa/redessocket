using RedesSockets.Mensagens;
using RedesSockets.Usuarios;
using System;
using System.Windows.Forms;

namespace RedesSockets
{
    public partial class MensagensForm : Form
    {
        private readonly UsuarioService _usuarioService;
        private readonly MensagemService _mensagemService;
        
        private Usuario Usuario;

        public MensagensForm()
        {
            InitializeComponent();
            DoLogin();

            // singleton
            _usuarioService = UsuarioService.GetInstance();
            _mensagemService = MensagemService.GetInstance();
        }

        private void DoLogin()
        {
            // Nesse ponto criamos de forma fixa o usuário logado na aplicação
            Usuario = new Usuario("USERID", "USERPASS", "USERNAME");
            // Adicionamos ele na lista de usuários logados...
            ListaUsuariosListBox.Items.Add(Usuario);
        }

        // Esse método é executado a cada "tick" do timmer de 6s
        private void ListarUsuariosTimmer_Tick(object sender, EventArgs e)
        {
            try
            {
                ListaUsuariosListBox.Items.Clear();
                // vamos adicionar manualmente, hotfix da primeira consulta
                ListaUsuariosListBox.Items.Add(Usuario);

                _usuarioService.ListarUsuarios(Usuario).ForEach(u =>
                {
                    // não vamos adicionar novamente, ja adicionamos antes
                    if (u.UserId == Usuario.UserId) return;
                    ListaUsuariosListBox.Items.Add(u);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Esse método é executado quando o botão de enviar mensagem é clicado
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
                // Upcast de object para Usuario (visto que carregamos o ListBox com List<Usuario>)
                // http://www.macoratti.net/20/04/c_updown1.htm
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

        // Esse método é executado quando o botão de receber mensagem é clicado
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
