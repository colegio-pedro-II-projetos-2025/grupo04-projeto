namespace YuGiOhTrabalhoWindowsForms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(370, 29);
            label1.Name = "label1";
            label1.Size = new Size(500, 191);
            label1.TabIndex = 0;
            label1.Text = "_______";
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(544, 274);
            button1.Name = "button1";
            button1.Size = new Size(159, 34);
            button1.TabIndex = 1;
            button1.Text = "Nova Partida";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(544, 326);
            button2.Name = "button2";
            button2.Size = new Size(159, 34);
            button2.TabIndex = 2;
            button2.Text = "Deck Manager";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Location = new Point(21, 12);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 3;
            button3.Text = "Entrar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(1102, 12);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 4;
            button4.Text = "Entrar";
            button4.UseVisualStyleBackColor = true;
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
            button5.Size = new Size(159, 34);
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
            button6.Location = new Point(544, 429);
            button6.Name = "button6";
            button6.Size = new Size(159, 34);
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
            label2.Location = new Point(5, 98);
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
            label3.Location = new Point(5, 138);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 10;
            label3.Text = "Senha:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1239, 594);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
    }
}
