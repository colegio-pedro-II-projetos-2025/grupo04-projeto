namespace YuGiOhTrabalhoWindowsForms
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            button1 = new Button();
            btnDeck = new Button();
            btnEntrarJgdr1 = new Button();
            btnEntrarJgdr2 = new Button();
            button5 = new Button();
            button6 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            lblAviso = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            pictureBox1 = new PictureBox();
            numericUpDown1 = new NumericUpDown();
            lblJgdr = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(544, 273);
            button1.Name = "button1";
            button1.Size = new Size(159, 33);
            button1.TabIndex = 1;
            button1.Text = "Nova Partida";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnDeck
            // 
            btnDeck.BackColor = Color.Black;
            btnDeck.BackgroundImage = (Image)resources.GetObject("btnDeck.BackgroundImage");
            btnDeck.BackgroundImageLayout = ImageLayout.Center;
            btnDeck.FlatStyle = FlatStyle.Popup;
            btnDeck.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeck.ForeColor = Color.Black;
            btnDeck.Location = new Point(544, 327);
            btnDeck.Name = "btnDeck";
            btnDeck.Size = new Size(159, 33);
            btnDeck.TabIndex = 2;
            btnDeck.Text = "Deck Manager";
            btnDeck.UseVisualStyleBackColor = false;
            btnDeck.Click += btnDeck_Click;
            // 
            // btnEntrarJgdr1
            // 
            btnEntrarJgdr1.Location = new Point(21, 12);
            btnEntrarJgdr1.Name = "btnEntrarJgdr1";
            btnEntrarJgdr1.Size = new Size(111, 33);
            btnEntrarJgdr1.TabIndex = 3;
            btnEntrarJgdr1.Text = "Entrar";
            btnEntrarJgdr1.UseVisualStyleBackColor = true;
            btnEntrarJgdr1.Click += btnEntrarJgdr1_Click;
            // 
            // btnEntrarJgdr2
            // 
            btnEntrarJgdr2.Location = new Point(1101, 12);
            btnEntrarJgdr2.Name = "btnEntrarJgdr2";
            btnEntrarJgdr2.Size = new Size(111, 33);
            btnEntrarJgdr2.TabIndex = 4;
            btnEntrarJgdr2.Text = "Entrar";
            btnEntrarJgdr2.UseVisualStyleBackColor = true;
            btnEntrarJgdr2.Click += btnEntrarJgdr2_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Black;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Center;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.Black;
            button5.Location = new Point(544, 377);
            button5.Name = "button5";
            button5.Size = new Size(159, 33);
            button5.TabIndex = 5;
            button5.Text = "Cadastro";
            button5.TextImageRelation = TextImageRelation.TextAboveImage;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Black;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Center;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(544, 428);
            button6.Name = "button6";
            button6.Size = new Size(159, 33);
            button6.TabIndex = 6;
            button6.Text = "Sair";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.NavajoWhite;
            textBox1.Location = new Point(79, 98);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.NavajoWhite;
            textBox2.Location = new Point(79, 135);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 98);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 9;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 138);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 10;
            label3.Text = "Senha:";
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.BackColor = Color.Transparent;
            lblAviso.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = Color.Red;
            lblAviso.Location = new Point(513, 480);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(91, 25);
            lblAviso.TabIndex = 17;
            lblAviso.Text = "lirili larila";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1003, 98);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 18;
            label1.Text = "Nome:";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.NavajoWhite;
            textBox3.Location = new Point(1071, 98);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(1003, 140);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 20;
            label4.Text = "Senha:";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.NavajoWhite;
            textBox4.Location = new Point(1071, 133);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(150, 31);
            textBox4.TabIndex = 21;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.YuGiOhLogoSmall;
            pictureBox1.Location = new Point(375, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(492, 182);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(802, 327);
            numericUpDown1.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(41, 31);
            numericUpDown1.TabIndex = 23;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblJgdr
            // 
            lblJgdr.AutoSize = true;
            lblJgdr.BackColor = Color.Transparent;
            lblJgdr.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJgdr.ForeColor = Color.White;
            lblJgdr.Location = new Point(709, 329);
            lblJgdr.Name = "lblJgdr";
            lblJgdr.Size = new Size(87, 25);
            lblJgdr.TabIndex = 24;
            lblJgdr.Text = "Jogador:";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1239, 593);
            Controls.Add(lblJgdr);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(lblAviso);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(btnEntrarJgdr2);
            Controls.Add(btnEntrarJgdr1);
            Controls.Add(btnDeck);
            Controls.Add(pictureBox1);
            Name = "MainMenuForm";
            Text = "Menu";
            Load += MainMenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button btnDeck;
        private Button btnEntrarJgdr1;
        private Button btnEntrarJgdr2;
        private Button button5;
        private Button button6;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Label lblAviso;
        private Label label1;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private PictureBox pictureBox1;
        private NumericUpDown numericUpDown1;
        private Label lblJgdr;
    }
}
