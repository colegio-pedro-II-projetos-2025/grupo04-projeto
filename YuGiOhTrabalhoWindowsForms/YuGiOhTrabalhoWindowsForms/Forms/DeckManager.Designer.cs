namespace YuGiOhTrabalhoWindowsForms
{
    partial class DeckManager
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
            cmbBxDecks = new ComboBox();
            lblDeck = new Label();
            flowLayoutPanelDeck = new FlowLayoutPanel();
            lblCapacidade = new Label();
            btnVisualizar = new Button();
            picBxCarta = new PictureBox();
            btnCriarDeck = new Button();
            flwLytPnlSummon = new FlowLayoutPanel();
            picBxCapacidade = new PictureBox();
            lblMin = new Label();
            lblIdJgdr = new Label();
            lblNomeDeck = new Label();
            txtBxNomeDeck = new TextBox();
            picBxInfo = new PictureBox();
            picBxBuscar = new PictureBox();
            pnlBuscar = new Panel();
            pnlAbaBuscar = new Panel();
            txtBxDefMin = new TextBox();
            txtBxAtkMin = new TextBox();
            cmbBxBuscarClasse = new ComboBox();
            cmbBxBuscarEfeito = new ComboBox();
            cmbBoxBuscarNome = new ComboBox();
            txtBxDefMax = new TextBox();
            txtBxAtkMax = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cmbBxOrdenar = new ComboBox();
            lblOrdenar = new Label();
            lblBuscarNome = new Label();
            lblBuscarEfeito = new Label();
            lblBuscarClasse = new Label();
            lblBuscarAtk = new Label();
            lblBuscarDef = new Label();
            pnlAbaBuscarEsquerda = new Panel();
            ((System.ComponentModel.ISupportInitialize)picBxCarta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBxCapacidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBxInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBxBuscar).BeginInit();
            pnlBuscar.SuspendLayout();
            pnlAbaBuscar.SuspendLayout();
            SuspendLayout();
            // 
            // cmbBxDecks
            // 
            cmbBxDecks.BackColor = Color.DarkGoldenrod;
            cmbBxDecks.ForeColor = Color.Black;
            cmbBxDecks.FormattingEnabled = true;
            cmbBxDecks.Location = new Point(11, 48);
            cmbBxDecks.Name = "cmbBxDecks";
            cmbBxDecks.Size = new Size(183, 33);
            cmbBxDecks.TabIndex = 0;
            // 
            // lblDeck
            // 
            lblDeck.AutoSize = true;
            lblDeck.BackColor = Color.DarkGoldenrod;
            lblDeck.ForeColor = SystemColors.ControlText;
            lblDeck.Location = new Point(11, 20);
            lblDeck.Name = "lblDeck";
            lblDeck.Size = new Size(63, 25);
            lblDeck.TabIndex = 1;
            lblDeck.Text = "Decks:";
            // 
            // flowLayoutPanelDeck
            // 
            flowLayoutPanelDeck.AllowDrop = true;
            flowLayoutPanelDeck.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanelDeck.AutoScroll = true;
            flowLayoutPanelDeck.BackColor = Color.DarkGoldenrod;
            flowLayoutPanelDeck.Location = new Point(234, 43);
            flowLayoutPanelDeck.Name = "flowLayoutPanelDeck";
            flowLayoutPanelDeck.Size = new Size(773, 570);
            flowLayoutPanelDeck.TabIndex = 2;
            // 
            // lblCapacidade
            // 
            lblCapacidade.AutoSize = true;
            lblCapacidade.BackColor = Color.FromArgb(128, 64, 0);
            lblCapacidade.Location = new Point(234, 20);
            lblCapacidade.Name = "lblCapacidade";
            lblCapacidade.Size = new Size(54, 25);
            lblCapacidade.TabIndex = 0;
            lblCapacidade.Text = "0/40 ";
            // 
            // btnVisualizar
            // 
            btnVisualizar.BackColor = Color.DarkGoldenrod;
            btnVisualizar.Location = new Point(11, 95);
            btnVisualizar.Margin = new Padding(0);
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Size = new Size(107, 38);
            btnVisualizar.TabIndex = 3;
            btnVisualizar.Text = "Visualizar";
            btnVisualizar.UseVisualStyleBackColor = false;
            btnVisualizar.Click += btnVisualizar_Click;
            // 
            // picBxCarta
            // 
            picBxCarta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            picBxCarta.BackColor = Color.Transparent;
            picBxCarta.BackgroundImage = Properties.Resources.TextBox;
            picBxCarta.Location = new Point(17, 285);
            picBxCarta.Margin = new Padding(4, 5, 4, 5);
            picBxCarta.Name = "picBxCarta";
            picBxCarta.Size = new Size(210, 320);
            picBxCarta.TabIndex = 4;
            picBxCarta.TabStop = false;
            // 
            // btnCriarDeck
            // 
            btnCriarDeck.BackColor = Color.DarkGoldenrod;
            btnCriarDeck.Location = new Point(11, 133);
            btnCriarDeck.Margin = new Padding(0);
            btnCriarDeck.Name = "btnCriarDeck";
            btnCriarDeck.Size = new Size(107, 38);
            btnCriarDeck.TabIndex = 6;
            btnCriarDeck.Text = "Criar";
            btnCriarDeck.UseVisualStyleBackColor = false;
            btnCriarDeck.Click += btnCriarDeck_Click;
            // 
            // flwLytPnlSummon
            // 
            flwLytPnlSummon.AllowDrop = true;
            flwLytPnlSummon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            flwLytPnlSummon.AutoScroll = true;
            flwLytPnlSummon.BackColor = Color.White;
            flwLytPnlSummon.Location = new Point(1023, 105);
            flwLytPnlSummon.Name = "flwLytPnlSummon";
            flwLytPnlSummon.Size = new Size(792, 508);
            flwLytPnlSummon.TabIndex = 7;
            // 
            // picBxCapacidade
            // 
            picBxCapacidade.BackColor = Color.FromArgb(128, 64, 0);
            picBxCapacidade.Location = new Point(234, 20);
            picBxCapacidade.Name = "picBxCapacidade";
            picBxCapacidade.Size = new Size(773, 25);
            picBxCapacidade.TabIndex = 0;
            picBxCapacidade.TabStop = false;
            // 
            // lblMin
            // 
            lblMin.AutoSize = true;
            lblMin.BackColor = Color.FromArgb(128, 64, 0);
            lblMin.Location = new Point(903, 20);
            lblMin.Name = "lblMin";
            lblMin.Size = new Size(81, 25);
            lblMin.TabIndex = 8;
            lblMin.Text = "(min. 20)";
            // 
            // lblIdJgdr
            // 
            lblIdJgdr.AutoSize = true;
            lblIdJgdr.Location = new Point(165, 140);
            lblIdJgdr.Name = "lblIdJgdr";
            lblIdJgdr.Size = new Size(62, 25);
            lblIdJgdr.TabIndex = 0;
            lblIdJgdr.Text = "IdJgdr";
            // 
            // lblNomeDeck
            // 
            lblNomeDeck.AutoSize = true;
            lblNomeDeck.BackColor = Color.FromArgb(128, 64, 0);
            lblNomeDeck.Location = new Point(294, 20);
            lblNomeDeck.Name = "lblNomeDeck";
            lblNomeDeck.Size = new Size(100, 25);
            lblNomeDeck.TabIndex = 9;
            lblNomeDeck.Text = "NomeDeck";
            // 
            // txtBxNomeDeck
            // 
            txtBxNomeDeck.BackColor = Color.DarkGoldenrod;
            txtBxNomeDeck.Location = new Point(11, 174);
            txtBxNomeDeck.Name = "txtBxNomeDeck";
            txtBxNomeDeck.Size = new Size(183, 31);
            txtBxNomeDeck.TabIndex = 0;
            // 
            // picBxInfo
            // 
            picBxInfo.BackColor = Color.FromArgb(128, 64, 0);
            picBxInfo.Image = Properties.Resources.simbolo_de_informacao;
            picBxInfo.Location = new Point(983, 20);
            picBxInfo.Name = "picBxInfo";
            picBxInfo.Size = new Size(24, 25);
            picBxInfo.SizeMode = PictureBoxSizeMode.StretchImage;
            picBxInfo.TabIndex = 10;
            picBxInfo.TabStop = false;
            // 
            // picBxBuscar
            // 
            picBxBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBxBuscar.BackColor = Color.Cyan;
            picBxBuscar.BorderStyle = BorderStyle.Fixed3D;
            picBxBuscar.Image = Properties.Resources.lupaBranca;
            picBxBuscar.Location = new Point(10, 11);
            picBxBuscar.Name = "picBxBuscar";
            picBxBuscar.Size = new Size(50, 50);
            picBxBuscar.SizeMode = PictureBoxSizeMode.StretchImage;
            picBxBuscar.TabIndex = 12;
            picBxBuscar.TabStop = false;
            picBxBuscar.Click += picBxBuscar_Click;
            picBxBuscar.MouseLeave += picBxBuscar_Leave;
            picBxBuscar.MouseHover += picBxBuscar_Hover;
            // 
            // pnlBuscar
            // 
            pnlBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlBuscar.BackColor = Color.White;
            pnlBuscar.Controls.Add(picBxBuscar);
            pnlBuscar.Location = new Point(732, 11);
            pnlBuscar.Name = "pnlBuscar";
            pnlBuscar.Size = new Size(70, 70);
            pnlBuscar.TabIndex = 13;
            // 
            // pnlAbaBuscar
            // 
            pnlAbaBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAbaBuscar.BackColor = Color.FromArgb(1, 12, 34);
            pnlAbaBuscar.Controls.Add(txtBxDefMin);
            pnlAbaBuscar.Controls.Add(txtBxAtkMin);
            pnlAbaBuscar.Controls.Add(cmbBxBuscarClasse);
            pnlAbaBuscar.Controls.Add(cmbBxBuscarEfeito);
            pnlAbaBuscar.Controls.Add(cmbBoxBuscarNome);
            pnlAbaBuscar.Controls.Add(txtBxDefMax);
            pnlAbaBuscar.Controls.Add(txtBxAtkMax);
            pnlAbaBuscar.Controls.Add(label2);
            pnlAbaBuscar.Controls.Add(label1);
            pnlAbaBuscar.Controls.Add(pnlBuscar);
            pnlAbaBuscar.Controls.Add(cmbBxOrdenar);
            pnlAbaBuscar.Controls.Add(lblOrdenar);
            pnlAbaBuscar.Controls.Add(lblBuscarNome);
            pnlAbaBuscar.Controls.Add(lblBuscarEfeito);
            pnlAbaBuscar.Controls.Add(lblBuscarClasse);
            pnlAbaBuscar.Controls.Add(lblBuscarAtk);
            pnlAbaBuscar.Controls.Add(lblBuscarDef);
            pnlAbaBuscar.Location = new Point(1013, 0);
            pnlAbaBuscar.Name = "pnlAbaBuscar";
            pnlAbaBuscar.Size = new Size(810, 99);
            pnlAbaBuscar.TabIndex = 14;
            // 
            // txtBxDefMin
            // 
            txtBxDefMin.BackColor = Color.FromArgb(1, 12, 34);
            txtBxDefMin.ForeColor = Color.White;
            txtBxDefMin.Location = new Point(585, 53);
            txtBxDefMin.Name = "txtBxDefMin";
            txtBxDefMin.Size = new Size(57, 31);
            txtBxDefMin.TabIndex = 26;
            txtBxDefMin.KeyPress += txtBxValorNumerico_KeyPress;
            // 
            // txtBxAtkMin
            // 
            txtBxAtkMin.BackColor = Color.FromArgb(1, 12, 34);
            txtBxAtkMin.ForeColor = Color.White;
            txtBxAtkMin.Location = new Point(585, 6);
            txtBxAtkMin.Name = "txtBxAtkMin";
            txtBxAtkMin.Size = new Size(57, 31);
            txtBxAtkMin.TabIndex = 25;
            txtBxAtkMin.KeyPress += txtBxValorNumerico_KeyPress;
            // 
            // cmbBxBuscarClasse
            // 
            cmbBxBuscarClasse.BackColor = Color.FromArgb(1, 12, 34);
            cmbBxBuscarClasse.ForeColor = Color.White;
            cmbBxBuscarClasse.FormattingEnabled = true;
            cmbBxBuscarClasse.Location = new Point(395, 6);
            cmbBxBuscarClasse.Name = "cmbBxBuscarClasse";
            cmbBxBuscarClasse.Size = new Size(146, 33);
            cmbBxBuscarClasse.TabIndex = 21;
            cmbBxBuscarClasse.Text = "         All";
            // 
            // cmbBxBuscarEfeito
            // 
            cmbBxBuscarEfeito.BackColor = Color.FromArgb(1, 12, 34);
            cmbBxBuscarEfeito.ForeColor = Color.White;
            cmbBxBuscarEfeito.FormattingEnabled = true;
            cmbBxBuscarEfeito.Location = new Point(395, 53);
            cmbBxBuscarEfeito.Name = "cmbBxBuscarEfeito";
            cmbBxBuscarEfeito.Size = new Size(146, 33);
            cmbBxBuscarEfeito.TabIndex = 22;
            cmbBxBuscarEfeito.Text = "         All";
            // 
            // cmbBoxBuscarNome
            // 
            cmbBoxBuscarNome.BackColor = Color.FromArgb(1, 12, 34);
            cmbBoxBuscarNome.ForeColor = Color.White;
            cmbBoxBuscarNome.FormattingEnabled = true;
            cmbBoxBuscarNome.Location = new Point(87, 53);
            cmbBoxBuscarNome.Name = "cmbBoxBuscarNome";
            cmbBoxBuscarNome.Size = new Size(242, 33);
            cmbBoxBuscarNome.TabIndex = 18;
            // 
            // txtBxDefMax
            // 
            txtBxDefMax.BackColor = Color.FromArgb(1, 12, 34);
            txtBxDefMax.ForeColor = Color.White;
            txtBxDefMax.Location = new Point(669, 53);
            txtBxDefMax.Name = "txtBxDefMax";
            txtBxDefMax.Size = new Size(57, 31);
            txtBxDefMax.TabIndex = 30;
            txtBxDefMax.KeyPress += txtBxValorNumerico_KeyPress;
            // 
            // txtBxAtkMax
            // 
            txtBxAtkMax.BackColor = Color.FromArgb(1, 12, 34);
            txtBxAtkMax.ForeColor = Color.White;
            txtBxAtkMax.Location = new Point(669, 6);
            txtBxAtkMax.Name = "txtBxAtkMax";
            txtBxAtkMax.Size = new Size(57, 31);
            txtBxAtkMax.TabIndex = 29;
            txtBxAtkMax.KeyPress += txtBxValorNumerico_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(648, 53);
            label2.Name = "label2";
            label2.Size = new Size(19, 25);
            label2.TabIndex = 28;
            label2.Text = "-";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(648, 9);
            label1.Name = "label1";
            label1.Size = new Size(19, 25);
            label1.TabIndex = 27;
            label1.Text = "-";
            // 
            // cmbBxOrdenar
            // 
            cmbBxOrdenar.BackColor = Color.FromArgb(1, 12, 34);
            cmbBxOrdenar.ForeColor = Color.White;
            cmbBxOrdenar.FormattingEnabled = true;
            cmbBxOrdenar.Location = new Point(87, 6);
            cmbBxOrdenar.Name = "cmbBxOrdenar";
            cmbBxOrdenar.Size = new Size(242, 33);
            cmbBxOrdenar.TabIndex = 16;
            // 
            // lblOrdenar
            // 
            lblOrdenar.AutoSize = true;
            lblOrdenar.ForeColor = Color.White;
            lblOrdenar.Location = new Point(10, 9);
            lblOrdenar.Name = "lblOrdenar";
            lblOrdenar.Size = new Size(81, 25);
            lblOrdenar.TabIndex = 15;
            lblOrdenar.Text = "Ordenar:";
            // 
            // lblBuscarNome
            // 
            lblBuscarNome.AutoSize = true;
            lblBuscarNome.ForeColor = Color.White;
            lblBuscarNome.Location = new Point(26, 56);
            lblBuscarNome.Name = "lblBuscarNome";
            lblBuscarNome.Size = new Size(65, 25);
            lblBuscarNome.TabIndex = 17;
            lblBuscarNome.Text = "Nome:";
            // 
            // lblBuscarEfeito
            // 
            lblBuscarEfeito.AutoSize = true;
            lblBuscarEfeito.ForeColor = Color.White;
            lblBuscarEfeito.Location = new Point(349, 56);
            lblBuscarEfeito.Name = "lblBuscarEfeito";
            lblBuscarEfeito.Size = new Size(51, 25);
            lblBuscarEfeito.TabIndex = 20;
            lblBuscarEfeito.Text = "Tipo:";
            // 
            // lblBuscarClasse
            // 
            lblBuscarClasse.AutoSize = true;
            lblBuscarClasse.ForeColor = Color.White;
            lblBuscarClasse.Location = new Point(335, 9);
            lblBuscarClasse.Name = "lblBuscarClasse";
            lblBuscarClasse.Size = new Size(65, 25);
            lblBuscarClasse.TabIndex = 19;
            lblBuscarClasse.Text = "Classe:";
            // 
            // lblBuscarAtk
            // 
            lblBuscarAtk.AutoSize = true;
            lblBuscarAtk.ForeColor = Color.White;
            lblBuscarAtk.Location = new Point(547, 9);
            lblBuscarAtk.Name = "lblBuscarAtk";
            lblBuscarAtk.Size = new Size(43, 25);
            lblBuscarAtk.TabIndex = 23;
            lblBuscarAtk.Text = "Atk:";
            // 
            // lblBuscarDef
            // 
            lblBuscarDef.AutoSize = true;
            lblBuscarDef.ForeColor = Color.White;
            lblBuscarDef.Location = new Point(547, 56);
            lblBuscarDef.Name = "lblBuscarDef";
            lblBuscarDef.Size = new Size(44, 25);
            lblBuscarDef.TabIndex = 24;
            lblBuscarDef.Text = "Def:";
            // 
            // pnlAbaBuscarEsquerda
            // 
            pnlAbaBuscarEsquerda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAbaBuscarEsquerda.BackColor = Color.FromArgb(128, 1, 12, 34);
            pnlAbaBuscarEsquerda.Location = new Point(957, -5);
            pnlAbaBuscarEsquerda.Name = "pnlAbaBuscarEsquerda";
            pnlAbaBuscarEsquerda.Size = new Size(60, 104);
            pnlAbaBuscarEsquerda.TabIndex = 15;
            // 
            // DeckManager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            BackgroundImage = Properties.Resources.DaVinciWorkshop_Summon;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1817, 625);
            Controls.Add(picBxInfo);
            Controls.Add(txtBxNomeDeck);
            Controls.Add(lblNomeDeck);
            Controls.Add(lblIdJgdr);
            Controls.Add(lblMin);
            Controls.Add(lblCapacidade);
            Controls.Add(flwLytPnlSummon);
            Controls.Add(btnCriarDeck);
            Controls.Add(picBxCarta);
            Controls.Add(btnVisualizar);
            Controls.Add(lblDeck);
            Controls.Add(cmbBxDecks);
            Controls.Add(picBxCapacidade);
            Controls.Add(flowLayoutPanelDeck);
            Controls.Add(pnlAbaBuscar);
            Controls.Add(pnlAbaBuscarEsquerda);
            DoubleBuffered = true;
            Name = "DeckManager";
            Text = "DeckManager - NomeJogador";
            ((System.ComponentModel.ISupportInitialize)picBxCarta).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBxCapacidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBxInfo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBxBuscar).EndInit();
            pnlBuscar.ResumeLayout(false);
            pnlAbaBuscar.ResumeLayout(false);
            pnlAbaBuscar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBxDecks;
        private Label lblDeck;
        private FlowLayoutPanel flowLayoutPanelDeck;
        private Button btnVisualizar;
        private PictureBox picBxCarta;
        private Button btnCriarDeck;
        private FlowLayoutPanel flwLytPnlSummon;
        private Label lblCapacidade;
        private PictureBox picBxCapacidade;
        private Label lblMin;
        private Label lblIdJgdr;
        private Label lblNomeDeck;
        private TextBox txtBxNomeDeck;
        private PictureBox picBxInfo;
        private PictureBox picBxBuscar;
        private Panel pnlBuscar;
        private Panel pnlAbaBuscar;
        private ComboBox cmbBoxBuscarNome;
        private Label lblBuscarNome;
        private ComboBox cmbBxOrdenar;
        private Label lblOrdenar;
        private ComboBox cmbBxBuscarClasse;
        private Label lblBuscarEfeito;
        private Label lblBuscarClasse;
        private ComboBox cmbBxBuscarEfeito;
        private TextBox txtBxAtkMin;
        private Label lblBuscarDef;
        private Label lblBuscarAtk;
        private TextBox txtBxDefMax;
        private TextBox txtBxAtkMax;
        private Label label2;
        private Label label1;
        private TextBox txtBxDefMin;
        private Panel pnlAbaBuscarEsquerda;
    }
}