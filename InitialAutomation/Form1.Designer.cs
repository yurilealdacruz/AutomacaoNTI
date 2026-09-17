namespace InitialAutomation
{
    partial class MainForm
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
            lblBanner = new Label();
            btnVerificarAtualizacao = new Button();
            grpDominio = new GroupBox();
            btnUsuariosLocais = new Button();
            button1 = new Button();
            btnSalvar = new Button();
            btnAdicionarDominio = new Button();
            chkLembrarSenha = new CheckBox();
            txtDominio = new TextBox();
            txtSenha = new TextBox();
            txtUsuario = new TextBox();
            txtNomePc = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            rtbLog = new RichTextBox();
            grpDominio.SuspendLayout();
            SuspendLayout();
            // 
            // lblBanner
            // 
            lblBanner.AutoSize = true;
            lblBanner.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBanner.Location = new Point(20, 15);
            lblBanner.Name = "lblBanner";
            lblBanner.Size = new Size(266, 34);
            lblBanner.TabIndex = 0;
            lblBanner.Text = "yurilealdacruz.github.io\nAutomação de Configuração de Máquinas";
            lblBanner.Click += label1_Click;
            // 
            // btnVerificarAtualizacao
            // 
            btnVerificarAtualizacao.Location = new Point(20, 58);
            btnVerificarAtualizacao.Name = "btnVerificarAtualizacao";
            btnVerificarAtualizacao.Size = new Size(160, 28);
            btnVerificarAtualizacao.TabIndex = 1;
            btnVerificarAtualizacao.Text = "Verificar Atualizações";
            btnVerificarAtualizacao.UseVisualStyleBackColor = true;
            btnVerificarAtualizacao.Click += btnVerificarAtualizacao_Click;
            // 
            // grpDominio
            // 
            grpDominio.Controls.Add(btnUsuariosLocais);
            grpDominio.Controls.Add(button1);
            grpDominio.Controls.Add(btnSalvar);
            grpDominio.Controls.Add(btnAdicionarDominio);
            grpDominio.Controls.Add(chkLembrarSenha);
            grpDominio.Controls.Add(txtDominio);
            grpDominio.Controls.Add(txtSenha);
            grpDominio.Controls.Add(txtUsuario);
            grpDominio.Controls.Add(txtNomePc);
            grpDominio.Controls.Add(label4);
            grpDominio.Controls.Add(label3);
            grpDominio.Controls.Add(label2);
            grpDominio.Controls.Add(label1);
            grpDominio.Location = new Point(20, 140);
            grpDominio.Name = "grpDominio";
            grpDominio.Size = new Size(490, 231);
            grpDominio.TabIndex = 2;
            grpDominio.TabStop = false;
            grpDominio.Text = "Configurações de Domínio e Nome";
            // 
            // btnUsuariosLocais
            // 
            btnUsuariosLocais.Location = new Point(304, 202);
            btnUsuariosLocais.Name = "btnUsuariosLocais";
            btnUsuariosLocais.Size = new Size(144, 23);
            btnUsuariosLocais.TabIndex = 6;
            btnUsuariosLocais.Text = "Limpar Usuários";
            btnUsuariosLocais.UseVisualStyleBackColor = true;
            btnUsuariosLocais.Click += btnUsuariosLocais_Click;
            // 
            // button1
            // 
            button1.Location = new Point(304, 175);
            button1.Name = "button1";
            button1.Size = new Size(144, 23);
            button1.TabIndex = 10;
            button1.Text = "Remover Domínio";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(148, 204);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(150, 23);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Salvar Configurações";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnAdicionarDominio
            // 
            btnAdicionarDominio.Location = new Point(148, 175);
            btnAdicionarDominio.Name = "btnAdicionarDominio";
            btnAdicionarDominio.Size = new Size(150, 23);
            btnAdicionarDominio.TabIndex = 9;
            btnAdicionarDominio.Text = "Adicionar Domínio";
            btnAdicionarDominio.UseVisualStyleBackColor = true;
            btnAdicionarDominio.Click += btnAdicionarDominio_Click;
            // 
            // chkLembrarSenha
            // 
            chkLembrarSenha.AutoSize = true;
            chkLembrarSenha.Location = new Point(154, 150);
            chkLembrarSenha.Name = "chkLembrarSenha";
            chkLembrarSenha.Size = new Size(144, 19);
            chkLembrarSenha.TabIndex = 8;
            chkLembrarSenha.Text = "Lembrar Login | Senha";
            chkLembrarSenha.UseVisualStyleBackColor = true;
            // 
            // txtDominio
            // 
            txtDominio.Location = new Point(148, 119);
            txtDominio.Name = "txtDominio";
            txtDominio.Size = new Size(300, 23);
            txtDominio.TabIndex = 7;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(148, 90);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(300, 23);
            txtSenha.TabIndex = 6;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(148, 61);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(300, 23);
            txtUsuario.TabIndex = 5;
            // 
            // txtNomePc
            // 
            txtNomePc.Location = new Point(148, 32);
            txtNomePc.Name = "txtNomePc";
            txtNomePc.Size = new Size(300, 23);
            txtNomePc.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 122);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 3;
            label4.Text = "Domínio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 95);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 2;
            label3.Text = "Senha do Domínio:";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 68);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 1;
            label2.Text = "Usuário do Domínio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 35);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Novo Nome do PC:";
            label1.Click += label1_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 391);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 4;
            label5.Text = "Log de Operações:";
            label5.Click += label5_Click;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = SystemColors.ActiveCaptionText;
            rtbLog.Font = new Font("Consolas", 9F);
            rtbLog.ForeColor = Color.Lime;
            rtbLog.Location = new Point(20, 409);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(490, 120);
            rtbLog.TabIndex = 5;
            rtbLog.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 611);
            Controls.Add(rtbLog);
            Controls.Add(label5);
            Controls.Add(grpDominio);
            Controls.Add(btnVerificarAtualizacao);
            Controls.Add(lblBanner);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Automação";
            Load += MainForm_Load;
            grpDominio.ResumeLayout(false);
            grpDominio.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBanner;
        private Button btnVerificarAtualizacao;
        private GroupBox grpDominio;
        private TextBox txtDominio;
        private TextBox txtSenha;
        private TextBox txtUsuario;
        private TextBox txtNomePc;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox chkLembrarSenha;
        private Button button1;
        private Button btnAdicionarDominio;
        private Button btnSalvar;
        private Label label5;
        private RichTextBox rtbLog;
        private Button btnUsuariosLocais;
    }
}
