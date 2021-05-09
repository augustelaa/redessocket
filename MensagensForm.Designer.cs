
namespace RedesSockets
{
    partial class MensagensForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ListaUsuariosListBox = new System.Windows.Forms.ListBox();
            this.listarUsuariosTimmer = new System.Windows.Forms.Timer(this.components);
            this.EnviarMensagemButton = new System.Windows.Forms.Button();
            this.MensagemTextBox = new System.Windows.Forms.TextBox();
            this.ListaMensagensTextBox = new System.Windows.Forms.TextBox();
            this.ReceberMensagemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListaUsuariosListBox
            // 
            this.ListaUsuariosListBox.FormattingEnabled = true;
            this.ListaUsuariosListBox.ItemHeight = 15;
            this.ListaUsuariosListBox.Location = new System.Drawing.Point(327, 12);
            this.ListaUsuariosListBox.Name = "ListaUsuariosListBox";
            this.ListaUsuariosListBox.Size = new System.Drawing.Size(204, 139);
            this.ListaUsuariosListBox.TabIndex = 0;
            // 
            // listarUsuariosTimmer
            // 
            this.listarUsuariosTimmer.Enabled = true;
            this.listarUsuariosTimmer.Interval = 6000;
            this.listarUsuariosTimmer.Tick += new System.EventHandler(this.ListarUsuariosTimmer_Tick);
            // 
            // EnviarMensagemButton
            // 
            this.EnviarMensagemButton.Location = new System.Drawing.Point(327, 157);
            this.EnviarMensagemButton.Name = "EnviarMensagemButton";
            this.EnviarMensagemButton.Size = new System.Drawing.Size(75, 23);
            this.EnviarMensagemButton.TabIndex = 1;
            this.EnviarMensagemButton.Text = "Enviar";
            this.EnviarMensagemButton.UseVisualStyleBackColor = true;
            this.EnviarMensagemButton.Click += new System.EventHandler(this.EnviarMensagemButton_Click);
            // 
            // MensagemTextBox
            // 
            this.MensagemTextBox.Location = new System.Drawing.Point(12, 157);
            this.MensagemTextBox.Name = "MensagemTextBox";
            this.MensagemTextBox.Size = new System.Drawing.Size(309, 23);
            this.MensagemTextBox.TabIndex = 2;
            // 
            // ListaMensagensTextBox
            // 
            this.ListaMensagensTextBox.Location = new System.Drawing.Point(12, 12);
            this.ListaMensagensTextBox.Multiline = true;
            this.ListaMensagensTextBox.Name = "ListaMensagensTextBox";
            this.ListaMensagensTextBox.ReadOnly = true;
            this.ListaMensagensTextBox.Size = new System.Drawing.Size(309, 139);
            this.ListaMensagensTextBox.TabIndex = 3;
            // 
            // ReceberMensagemButton
            // 
            this.ReceberMensagemButton.Location = new System.Drawing.Point(408, 157);
            this.ReceberMensagemButton.Name = "ReceberMensagemButton";
            this.ReceberMensagemButton.Size = new System.Drawing.Size(75, 23);
            this.ReceberMensagemButton.TabIndex = 4;
            this.ReceberMensagemButton.Text = "Receber";
            this.ReceberMensagemButton.UseVisualStyleBackColor = true;
            this.ReceberMensagemButton.Click += new System.EventHandler(this.ReceberMensagemButton_Click);
            // 
            // Aplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 198);
            this.Controls.Add(this.ReceberMensagemButton);
            this.Controls.Add(this.ListaMensagensTextBox);
            this.Controls.Add(this.MensagemTextBox);
            this.Controls.Add(this.EnviarMensagemButton);
            this.Controls.Add(this.ListaUsuariosListBox);
            this.Name = "Aplicacao";
            this.Text = "LARC - 5º Laboratório";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListaUsuariosListBox;
        private System.Windows.Forms.Timer listarUsuariosTimmer;
        private System.Windows.Forms.Button EnviarMensagemButton;
        private System.Windows.Forms.TextBox MensagemTextBox;
        private System.Windows.Forms.TextBox ListaMensagensTextBox;
        private System.Windows.Forms.Button ReceberMensagemButton;
    }
}

