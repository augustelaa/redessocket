
namespace RedesSockets
{
    partial class aplicacao
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
            this.listaUsuariosListBox = new System.Windows.Forms.ListBox();
            this.listarUsuariosTimmer = new System.Windows.Forms.Timer(this.components);
            this.enviarMensagemButton = new System.Windows.Forms.Button();
            this.mensagemTextBox = new System.Windows.Forms.TextBox();
            this.listaMensagensTextBox = new System.Windows.Forms.TextBox();
            this.receberMensagemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listaUsuariosListBox
            // 
            this.listaUsuariosListBox.FormattingEnabled = true;
            this.listaUsuariosListBox.ItemHeight = 15;
            this.listaUsuariosListBox.Location = new System.Drawing.Point(327, 12);
            this.listaUsuariosListBox.Name = "listaUsuariosListBox";
            this.listaUsuariosListBox.Size = new System.Drawing.Size(204, 139);
            this.listaUsuariosListBox.TabIndex = 0;
            // 
            // listarUsuariosTimmer
            // 
            this.listarUsuariosTimmer.Enabled = true;
            this.listarUsuariosTimmer.Interval = 6000;
            this.listarUsuariosTimmer.Tick += new System.EventHandler(this.listarUsuariosTimmer_Tick);
            // 
            // enviarMensagemButton
            // 
            this.enviarMensagemButton.Location = new System.Drawing.Point(327, 157);
            this.enviarMensagemButton.Name = "enviarMensagemButton";
            this.enviarMensagemButton.Size = new System.Drawing.Size(75, 23);
            this.enviarMensagemButton.TabIndex = 1;
            this.enviarMensagemButton.Text = "Enviar";
            this.enviarMensagemButton.UseVisualStyleBackColor = true;
            this.enviarMensagemButton.Click += new System.EventHandler(this.enviarMensagemButton_Click);
            // 
            // mensagemTextBox
            // 
            this.mensagemTextBox.Location = new System.Drawing.Point(12, 157);
            this.mensagemTextBox.Name = "mensagemTextBox";
            this.mensagemTextBox.Size = new System.Drawing.Size(309, 23);
            this.mensagemTextBox.TabIndex = 2;
            // 
            // listaMensagensTextBox
            // 
            this.listaMensagensTextBox.Location = new System.Drawing.Point(12, 12);
            this.listaMensagensTextBox.Multiline = true;
            this.listaMensagensTextBox.Name = "listaMensagensTextBox";
            this.listaMensagensTextBox.ReadOnly = true;
            this.listaMensagensTextBox.Size = new System.Drawing.Size(309, 139);
            this.listaMensagensTextBox.TabIndex = 3;
            // 
            // receberMensagemButton
            // 
            this.receberMensagemButton.Location = new System.Drawing.Point(408, 157);
            this.receberMensagemButton.Name = "receberMensagemButton";
            this.receberMensagemButton.Size = new System.Drawing.Size(75, 23);
            this.receberMensagemButton.TabIndex = 4;
            this.receberMensagemButton.Text = "Receber";
            this.receberMensagemButton.UseVisualStyleBackColor = true;
            this.receberMensagemButton.Click += new System.EventHandler(this.receberMensagemButton_Click);
            // 
            // aplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 198);
            this.Controls.Add(this.receberMensagemButton);
            this.Controls.Add(this.listaMensagensTextBox);
            this.Controls.Add(this.mensagemTextBox);
            this.Controls.Add(this.enviarMensagemButton);
            this.Controls.Add(this.listaUsuariosListBox);
            this.Name = "aplicacao";
            this.Text = "LARC - 5º Laboratório";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listaUsuariosListBox;
        private System.Windows.Forms.Timer listarUsuariosTimmer;
        private System.Windows.Forms.Button enviarMensagemButton;
        private System.Windows.Forms.TextBox mensagemTextBox;
        private System.Windows.Forms.TextBox listaMensagensTextBox;
        private System.Windows.Forms.Button receberMensagemButton;
    }
}

