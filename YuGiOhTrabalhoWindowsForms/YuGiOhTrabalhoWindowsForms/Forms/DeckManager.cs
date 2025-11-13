using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOhTrabalhoWindowsForms.Repositorio;
using YuGiOhTrabalhoWindowsForms.Util;
using YuGiOhTrabalhoWindowsForms.Entidade;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using YuGiOhTrabalhoWindowsForms.Properties;

namespace YuGiOhTrabalhoWindowsForms
{
    public partial class DeckManager : Form
    {
        DeckRepository repoDeck = new DeckRepository(DbUtil.ConnectionString);
        CartaRepository repoCarta = new CartaRepository(DbUtil.ConnectionString);

        public DeckManager(int jgdr, string jgdr1, string jgdr2, int jgdrSelect)
        {
            InitializeComponent();

            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(picBxInfo, $"Arraste as cartas até o deck para adicioná-las a ele.");

            //this.FormBorderStyle = FormBorderStyle.None; // Removes window borders
            this.WindowState = FormWindowState.Maximized; // Maximizes to full screen
            this.TopMost = false; // Keeps the form on top (optional)
            this.BackgroundImage = Resources.DaVinciWorkshop;
            this.BackgroundImage.Tag = "DaVinciWorkshop";

            int jgdrSelecionado = jgdr;
            string jgdrNome = "";

            if (jgdrSelect > 0)
                jgdrSelecionado = jgdrSelect;

            if (jgdrSelecionado == 1)
                jgdrNome = jgdr1;
            else
                jgdrNome = jgdr2;

            this.Text = $"DeckManager - {jgdrNome}";

            //Acochambramento:
            lblIdJgdr.Text = DbUtil.BuscarIdJogador(jgdrNome).ToString();

            List<string> decks = repoDeck.BuscarDecksPorJogador(jgdrNome);

            for (int i = 0; i < decks.Count; i++)
            {
                cmbBxDecks.Items.Add(decks[i]);
            }

            pnlAbaBuscarEsquerda.BackColor = Color.FromArgb(204, 1, 12, 34);
            flwLytPnlSummon.BackColor = Color.Transparent;
            picBxCarta.Visible = false;

            flowLayoutPanelDeck.DragEnter += flowLayoutPanelDeck_DragEnter;
            flowLayoutPanelDeck.DragDrop += flowLayoutPanelDeck_DragDrop;

            flwLytPnlSummon.DragEnter += flwLytPnlSummon_DragEnter;
            flwLytPnlSummon.DragDrop += flwLytPnlSummon_DragDrop;

            lblIdJgdr.Visible = false;

            txtBxNomeDeck.PlaceholderText = "Digite o nome do deck...";
            txtBxNomeDeck.Visible = false;

            TornarControlesDeckVisiveis(false);

            // Inicialização das comboBox

            cmbBxOrdenar.Items.Add("Raridade (Maior p/ Menor)");
            cmbBxOrdenar.Items.Add("Raridade (Menor p/ Maior)");
            cmbBxOrdenar.Items.Add("Atk (Maior p/ Menor)");
            cmbBxOrdenar.Items.Add("Atk (Menor p/ Maior)");
            cmbBxOrdenar.Items.Add("Def (Maior p/ Menor)");
            cmbBxOrdenar.Items.Add("Def (Menor p/ Maior)");
            cmbBxOrdenar.Items.Add("Nome (A → Z)");
            cmbBxOrdenar.Items.Add("Nome (Z → A)");
            cmbBxOrdenar.SelectedIndex = 0;

            cmbBxBuscarClasse.Items.Add("         All");
            cmbBxBuscarClasse.Items.Add("    Shielder");
            cmbBxBuscarClasse.Items.Add("    Saber");
            cmbBxBuscarClasse.Items.Add("    Archer");
            cmbBxBuscarClasse.Items.Add("    Lancer");
            cmbBxBuscarClasse.Items.Add("    Rider");
            cmbBxBuscarClasse.Items.Add("    Caster");
            cmbBxBuscarClasse.Items.Add("    Assassin");
            cmbBxBuscarClasse.Items.Add("    Berserker");
            cmbBxBuscarClasse.Items.Add("    Ruler");
            cmbBxBuscarClasse.Items.Add("    Avenger");
            cmbBxBuscarClasse.Items.Add("  Moon Cancer");
            cmbBxBuscarClasse.Items.Add("    Alter Ego");
            cmbBxBuscarClasse.Items.Add("    Foreigner");
            cmbBxBuscarClasse.Items.Add("    Pretender");
            cmbBxBuscarClasse.Items.Add("    Beast");
            cmbBxBuscarClasse.Items.Add("  Knight Classes");
            cmbBxBuscarClasse.Items.Add("  Extra Classes");
            cmbBxOrdenar.SelectedIndex = 0;

            cmbBxBuscarEfeito.Items.Add("         All");
            cmbBxBuscarEfeito.Items.Add("    Normal");
            cmbBxBuscarEfeito.Items.Add("    Efeito");
            cmbBxBuscarEfeito.Items.Add("    Magia");
            cmbBxBuscarEfeito.Items.Add("  Magia Rápida");
            cmbBxBuscarEfeito.Items.Add("    Armadilha");
            cmbBxBuscarEfeito.Items.Add("  Armadilha Contínua");
            cmbBxBuscarEfeito.Items.Add("    Campo");
            cmbBxOrdenar.SelectedIndex = 0;

            txtBxAtkMin.PlaceholderText = "Atk Mínimo";
            txtBxAtkMax.PlaceholderText = "Atk Máximo";
            txtBxDefMin.PlaceholderText = "Def Mínima";
            txtBxDefMax.PlaceholderText = "Def Máxima";

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            btnCriarDeck.Text = "Criar";
            txtBxNomeDeck.Text = string.Empty;
            txtBxNomeDeck.Visible = false;

            List<Carta> cartas = new List<Carta>();

            if (cmbBxDecks.Text == "" || repoDeck.ValidarDeck(cmbBxDecks.Text, Convert.ToInt32(lblIdJgdr.Text)) == false)
                MessageBox.Show("Nenhum deck válido selecionado.");
            else
            {
                flowLayoutPanelDeck.Controls.Clear();

                cartas = repoDeck.TrazerCartas(cmbBxDecks.Text);

                lblNomeDeck.Text = cmbBxDecks.Text;

                foreach (Carta carta in cartas)
                {
                    Carta novaCarta = new Carta
                    {
                        Id_Carta = carta.Id_Carta,
                        Nome = carta.Nome,
                        Atk = carta.Atk,
                        Def = carta.Def,
                        Classe = carta.Classe,
                        Efeito = carta.Efeito,
                        Image = carta.Image,
                        Size = carta.Size
                    };

                    flowLayoutPanelDeck.Controls.Add(novaCarta);

                    novaCarta.Click += carta_Click;
                    novaCarta.MouseDown += carta_Segurar;

                    System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                    toolTip.AutoPopDelay = 5000;
                    toolTip.InitialDelay = 500;
                    toolTip.ReshowDelay = 200;
                    toolTip.ShowAlways = true;

                    toolTip.SetToolTip(novaCarta, $"Informações sobre a carta:\n\n Nome: {novaCarta.Nome}\n Atk: {novaCarta.Atk}\n Def: {novaCarta.Def}\n Classe: {novaCarta.Classe}\n {novaCarta.Efeito}");
                }

                cartas.Clear();

                // Perguntar : MessageBox.Show(this.BackgroundImage == Resources.DaVinciWorkshop ? "Imagens Iguais" : "Imagens Diferentes");

                if (this.BackgroundImage.Tag == "DaVinciWorkshop")
                {
                    cartas = repoCarta.TrazerCartasSummon();

                    foreach (Carta carta in cartas)
                    {
                        flwLytPnlSummon.Controls.Add(carta);
                        carta.Click += carta_Click;
                        carta.MouseDown += carta_Segurar;
                        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                        toolTip.AutoPopDelay = 5000;
                        toolTip.InitialDelay = 500;
                        toolTip.ReshowDelay = 200;
                        toolTip.ShowAlways = true;

                        toolTip.SetToolTip(carta, $"Informações sobre a carta:\n\n Nome: {carta.Nome}\n Poder: {carta.Atk}\n Def: {carta.Def}\n Classe: {carta.Classe}\n {carta.Efeito}");
                    }

                    this.BackgroundImage.Tag = "DaVinciWorkshop_Summon";
                }

                this.BackgroundImage = Resources.DaVinciWorkshop_Summon;

                lblCapacidade.Text = flowLayoutPanelDeck.Controls.Count.ToString() + "/40";

                TornarControlesDeckVisiveis(true);

            }

        }

        private void carta_Click(object sender, EventArgs e)
        {
            Carta cartaQueDisparouOEvento = (Carta)sender;

            picBxCarta.BackgroundImage = null;
            picBxCarta.Image = cartaQueDisparouOEvento.Image;
            picBxCarta.SizeMode = PictureBoxSizeMode.StretchImage;
            picBxCarta.Visible = true;


        }

        private void carta_Segurar(object sender, EventArgs e)
        {
            Carta carta = (Carta)sender;

            picBxCarta.BackgroundImage = null;
            picBxCarta.Image = carta.Image;
            picBxCarta.SizeMode = PictureBoxSizeMode.StretchImage;
            picBxCarta.Visible = true;

            DoDragDrop(carta, DragDropEffects.Move);

        }

        private void flowLayoutPanelDeck_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Carta)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void flowLayoutPanelDeck_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Carta)))
            {
                Carta cartaOriginal = (Carta)e.Data.GetData(typeof(Carta));

                /*Carta carta = (Carta)e.Data.GetData(typeof(Carta));

                // Remove a carta do painel de origem (opcional)
                //flwLytPnlSummon.Controls.Remove(carta);

                // Adiciona a carta ao painel de destino
                flowLayoutPanelDeck.Controls.Add(carta);*/

                // Verifica se a carta já está no flowLayoutPanelDeck
                if (flowLayoutPanelDeck.Controls.Contains(cartaOriginal))
                {
                    return;
                }

                int quantidade = 0;
                for (int i = 0; i < flowLayoutPanelDeck.Controls.Count; i++)
                {
                    Carta cartaExistente = (Carta)flowLayoutPanelDeck.Controls[i];

                    if (cartaExistente.Nome == cartaOriginal.Nome && cartaExistente.Classe == cartaOriginal.Classe)
                    {
                        quantidade++;
                    }
                }

                if (quantidade == cartaOriginal.Limite)
                {
                    MessageBox.Show($"Você já possui {quantidade} cartas {cartaOriginal.Nome} no deck. O limite de cartas {cartaOriginal.Nome} por deck é {cartaOriginal.Limite}.");
                    return;
                }

                if (flowLayoutPanelDeck.Controls.Count >= 40)
                {
                    MessageBox.Show("O deck já está cheio. Não é possível adicionar mais cartas.");
                    return;
                }
                else
                {
                    // Cria uma nova instância da carta
                    Carta novaCarta = new Carta
                    {
                        Id_Carta = cartaOriginal.Id_Carta,
                        Nome = cartaOriginal.Nome,
                        Atk = cartaOriginal.Atk,
                        Classe = cartaOriginal.Classe,
                        Image = cartaOriginal.Image,
                        Size = cartaOriginal.Size,
                        Efeito = cartaOriginal.Efeito
                    };

                    // Adiciona a nova carta ao painel de destino
                    flowLayoutPanelDeck.Controls.Add(novaCarta);

                    // Opcional: Adiciona eventos à nova carta
                    novaCarta.Click += carta_Click;
                    novaCarta.MouseDown += carta_Segurar;

                    System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                    toolTip.AutoPopDelay = 5000;
                    toolTip.InitialDelay = 500;
                    toolTip.ReshowDelay = 200;
                    toolTip.ShowAlways = true;

                    toolTip.SetToolTip(novaCarta, $"Informações sobre a carta:\n\n Nome: {novaCarta.Nome}\n Poder: {novaCarta.Atk}\n Def: {novaCarta.Def}\n Classe: {novaCarta.Classe}\n {novaCarta.Efeito}");

                    lblCapacidade.Text = flowLayoutPanelDeck.Controls.Count.ToString() + "/40";

                    if (btnCriarDeck.Text != "Criar")
                    {
                        return;
                    }

                    int id_jogador = Convert.ToInt32(lblIdJgdr.Text);
                    repoDeck.InserirCartaDeck(lblNomeDeck.Text, id_jogador, novaCarta.Id_Carta, quantidade);

                }

            }
        }

        private void flwLytPnlSummon_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Carta)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void flwLytPnlSummon_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Carta)))
            {
                Carta cartaOriginal = (Carta)e.Data.GetData(typeof(Carta));

                if (flwLytPnlSummon.Controls.Contains(cartaOriginal))
                {
                    return;
                }

                else
                {
                    int quantidade = 0;
                    for (int i = 0; i < flowLayoutPanelDeck.Controls.Count; i++)
                    {
                        Carta cartaExistente = (Carta)flowLayoutPanelDeck.Controls[i];

                        if (cartaExistente.Nome == cartaOriginal.Nome && cartaExistente.Classe == cartaOriginal.Classe)
                        {
                            quantidade++;
                        }
                    }

                    flowLayoutPanelDeck.Controls.Remove(cartaOriginal);

                    lblCapacidade.Text = flowLayoutPanelDeck.Controls.Count.ToString() + "/40";

                    int id_jogador = Convert.ToInt32(lblIdJgdr.Text);
                    repoDeck.RemoverCartaDeck(cartaOriginal.Id_Carta, quantidade, lblNomeDeck.Text, id_jogador);

                }

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnCriarDeck_Click(object sender, EventArgs e)
        {
            if (btnCriarDeck.Text == "Confirmar" && txtBxNomeDeck.Visible == true)
            {
                if (string.IsNullOrWhiteSpace(txtBxNomeDeck.Text.Trim()) == false)
                {
                    if (repoDeck.ValidarDeck(txtBxNomeDeck.Text, Convert.ToInt32(lblIdJgdr.Text)))
                    {
                        MessageBox.Show("Já existe um deck com esse nome.");
                        return;
                    }

                    if (txtBxNomeDeck.Text.Trim().Length > 20)
                    {
                        MessageBox.Show("Nome do deck não pode ter mais que 20 caracteres.");
                        return;
                    }

                    else
                    {
                        this.BackgroundImage = Resources.DaVinciWorkshop_Summon;
                        this.BackgroundImage.Tag = "DaVinciWorkshop_Summon";

                        List<Carta> cartas = new List<Carta>();
                        cartas = repoCarta.TrazerCartasSummon();

                        foreach (Carta carta in cartas)
                        {
                            flwLytPnlSummon.Controls.Add(carta);
                            carta.Click += carta_Click;
                            carta.MouseDown += carta_Segurar;
                            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                            toolTip.AutoPopDelay = 5000;
                            toolTip.InitialDelay = 500;
                            toolTip.ReshowDelay = 200;
                            toolTip.ShowAlways = true;

                            toolTip.SetToolTip(carta, $"Informações sobre a carta:\n\n Nome: {carta.Nome}\n Poder: {carta.Atk}\n Def: {carta.Def}\n Classe: {carta.Classe}\n {carta.Efeito}");
                        }

                        flowLayoutPanelDeck.Controls.Clear();

                        lblCapacidade.Text = flowLayoutPanelDeck.Controls.Count.ToString() + "/40";

                        TornarControlesDeckVisiveis(true);

                        lblNomeDeck.Text = txtBxNomeDeck.Text;

                        btnCriarDeck.Text = "Finalizar";

                        txtBxNomeDeck.Visible = false;

                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtBxNomeDeck.Text.Trim()))
                    {
                        MessageBox.Show("O nome do deck não pode estar vazio.");
                        return;
                    }
                }
            }
            else if (btnCriarDeck.Text == "Criar" && txtBxNomeDeck.Visible == false)
            {
                txtBxNomeDeck.Visible = true;

                btnCriarDeck.Text = "Confirmar";
            }
            else if (btnCriarDeck.Text == "Finalizar" && txtBxNomeDeck.Visible == false)
            {

                if (flowLayoutPanelDeck.Controls.Count < 20)
                {
                    MessageBox.Show("O deck deve conter no mínimo 20 cartas.");
                    return;
                }

                List<Carta> cartas = new List<Carta>();
                foreach (Control control in flowLayoutPanelDeck.Controls)
                {
                    cartas.Add((Carta)control);
                }
                int id_jogador = Convert.ToInt32(lblIdJgdr.Text);
                repoDeck.CriarDeck(txtBxNomeDeck.Text, id_jogador, cartas);

                cmbBxDecks.Items.Add(txtBxNomeDeck.Text);
                cmbBxDecks.SelectedItem = txtBxNomeDeck.Text;

                MessageBox.Show("Deck criado com sucesso!");

                btnVisualizar_Click(sender, e);

            }

        }

        private void picBxBuscar_Hover(object sender, EventArgs e)
        {
            picBxBuscar.BackColor = Color.DarkCyan;
        }

        private void picBxBuscar_Leave(object sender, EventArgs e)
        {
            picBxBuscar.BackColor = Color.Cyan;
        }

        private void TornarControlesDeckVisiveis(bool estadoDesejado)
        {
            if (estadoDesejado)
            {
                flowLayoutPanelDeck.Visible = true;
                pnlBuscar.Visible = true;
                pnlAbaBuscar.Visible = true;
                pnlAbaBuscarEsquerda.Visible = true;

                picBxCapacidade.Visible = true;
                picBxInfo.Visible = true;
                picBxBuscar.Visible = true;

                lblCapacidade.Visible = true;
                lblMin.Visible = true;
                lblNomeDeck.Visible = true;
                lblOrdenar.Visible = true;
                lblBuscarNome.Visible = true;
                lblBuscarClasse.Visible = true;
                lblBuscarEfeito.Visible = true;
                lblBuscarAtk.Visible = true;
                lblBuscarDef.Visible = true;
                label1.Visible = true; // -
                label2.Visible = true; // - 

                txtBxAtkMin.Visible = true;
                txtBxAtkMax.Visible = true;
                txtBxDefMin.Visible = true;
                txtBxDefMax.Visible = true;

                cmbBxOrdenar.Visible = true;
                cmbBoxBuscarNome.Visible = true;
                cmbBxBuscarClasse.Visible = true;
                cmbBxBuscarEfeito.Visible = true;

            }

            else
            {
                flowLayoutPanelDeck.Visible = false;
                pnlBuscar.Visible = false;
                pnlAbaBuscar.Visible = false;
                pnlAbaBuscarEsquerda.Visible = false;

                picBxCapacidade.Visible = false;
                picBxInfo.Visible = false;
                picBxBuscar.Visible = false;

                lblCapacidade.Visible = false;
                lblMin.Visible = false;
                lblNomeDeck.Visible = false;
                lblOrdenar.Visible = false;
                lblBuscarNome.Visible = false;
                lblBuscarClasse.Visible = false;
                lblBuscarEfeito.Visible = false;
                lblBuscarAtk.Visible = false;
                lblBuscarDef.Visible = false;
                label1.Visible = false; // -
                label2.Visible = false; // - 

                txtBxAtkMin.Visible = false;
                txtBxAtkMax.Visible = false;
                txtBxDefMin.Visible = false;
                txtBxDefMax.Visible = false;

                cmbBxOrdenar.Visible = false;
                cmbBoxBuscarNome.Visible = false;
                cmbBxBuscarClasse.Visible = false;
                cmbBxBuscarEfeito.Visible = false;

            }

        }

        private void picBxBuscar_Click(object sender, EventArgs e)
        {
            flwLytPnlSummon.Controls.Clear();

            bool itemEncontrado = false;

            foreach (var item in cmbBxOrdenar.Items)
            {
                if (item.ToString().Equals(cmbBxOrdenar.Text, StringComparison.OrdinalIgnoreCase))
                {
                    itemEncontrado = true;
                    break;
                }
            }
            if (!itemEncontrado)
                cmbBxOrdenar.SelectedIndex = 0;
            itemEncontrado = false;

            foreach (var item in cmbBxBuscarClasse.Items)
            {
                if (item.ToString().Equals(cmbBxBuscarClasse.Text, StringComparison.OrdinalIgnoreCase))
                {
                    itemEncontrado = true;
                    break;
                }
            }
            if (!itemEncontrado)
                cmbBxBuscarClasse.SelectedIndex = 0;
            itemEncontrado = false;

            foreach (var item in cmbBxBuscarEfeito.Items)
            {
                if (item.ToString().Equals(cmbBxBuscarEfeito.Text, StringComparison.OrdinalIgnoreCase))
                {
                    itemEncontrado = true;
                    break;
                }
            }
            if (!itemEncontrado)
                cmbBxBuscarEfeito.SelectedIndex = 0;

            if (string.IsNullOrWhiteSpace(txtBxAtkMin.Text.Trim()))
                txtBxAtkMin.Text = "0";
            if (string.IsNullOrWhiteSpace(txtBxAtkMax.Text.Trim()))
                txtBxAtkMax.Text = "0";
            if (string.IsNullOrWhiteSpace(txtBxDefMin.Text.Trim()))
                txtBxDefMin.Text = "0";
            if (string.IsNullOrWhiteSpace(txtBxDefMax.Text.Trim()))
                txtBxDefMax.Text = "0";

            List<Carta> cartas = new List<Carta>();

            cartas = repoCarta.TrazerCartasSummon(cmbBxOrdenar.Text, cmbBoxBuscarNome.Text.Trim(), cmbBxBuscarClasse.Text.Trim(), cmbBxBuscarEfeito.Text.Trim(), Convert.ToInt32(txtBxAtkMin.Text), Convert.ToInt32(txtBxAtkMax.Text), Convert.ToInt32(txtBxDefMin.Text), Convert.ToInt32(txtBxDefMax.Text));

            foreach (Carta carta in cartas)
            {
                flwLytPnlSummon.Controls.Add(carta);
                carta.Click += carta_Click;
                carta.MouseDown += carta_Segurar;
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                toolTip.AutoPopDelay = 5000;
                toolTip.InitialDelay = 500;
                toolTip.ReshowDelay = 200;
                toolTip.ShowAlways = true;

                toolTip.SetToolTip(carta, $"Informações sobre a carta:\n\n Nome: {carta.Nome}\n Poder: {carta.Atk}\n Def: {carta.Def}\n Classe: {carta.Classe}\n {carta.Efeito}");
            }

        }

        private void txtBxValorNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos e teclas de controle (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela o caractere
            }
        }
        
    }

}
