namespace YuGiOhTrabalhoWindowsForms
{
    partial class CadastroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroForm));
            label2 = new Label();
            txtNome = new TextBox();
            label3 = new Label();
            txtSenha = new TextBox();
            button6 = new Button();
            button1 = new Button();
            lblAviso = new Label();
            label1 = new Label();
            txtConfirmarSenha = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(48, 58);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 10;
            label2.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.NavajoWhite;
            txtNome.Location = new Point(122, 58);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(150, 31);
            txtNome.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(48, 95);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 12;
            label3.Text = "Senha:";
            // 
            // txtSenha
            // 
            txtSenha.BackColor = Color.NavajoWhite;
            txtSenha.Location = new Point(122, 95);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(150, 31);
            txtSenha.TabIndex = 13;
            // 
            // button6
            // 
            button6.BackColor = Color.Black;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Center;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(80, 287);
            button6.Name = "button6";
            button6.Size = new Size(159, 34);
            button6.TabIndex = 14;
            button6.Text = "Voltar";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(80, 229);
            button1.Name = "button1";
            button1.Size = new Size(159, 34);
            button1.TabIndex = 15;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.BackColor = Color.Transparent;
            lblAviso.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = Color.Red;
            lblAviso.Location = new Point(21, 191);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(91, 25);
            lblAviso.TabIndex = 16;
            lblAviso.Text = "lirili larila";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 138);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 17;
            label1.Text = "Confirme:";
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.BackColor = Color.NavajoWhite;
            txtConfirmarSenha.Location = new Point(122, 138);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.PasswordChar = '*';
            txtConfirmarSenha.Size = new Size(150, 31);
            txtConfirmarSenha.TabIndex = 18;
            // 
            // CadastroForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(337, 450);
            Controls.Add(txtConfirmarSenha);
            Controls.Add(label1);
            Controls.Add(lblAviso);
            Controls.Add(button1);
            Controls.Add(button6);
            Controls.Add(txtSenha);
            Controls.Add(label3);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Name = "CadastroForm";
            Text = "Cadastro";
            Load += CadastroForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtNome;
        private Label label3;
        private TextBox txtSenha;
        private Button button6;
        private Button button1;
        private Label lblAviso;
        private Label label1;
        private TextBox txtConfirmarSenha;
    }
}