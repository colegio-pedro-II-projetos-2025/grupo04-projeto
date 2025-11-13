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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace YuGiOhTrabalhoWindowsForms.Forms
{
    public partial class BatalhaForm : Form
    {
        DeckRepository repoDeck = new DeckRepository(DbUtil.ConnectionString);
        BatalhaRepository repoBatalha = new BatalhaRepository(DbUtil.ConnectionString);
        private int turno = 1;
        public int vidaJgdr1 = 8000;
        public int vidaJgdr2 = 8000;
        public bool summonFadiga = false;
        List<Carta> Deck1 = new List<Carta>();
        List<Carta> Deck2 = new List<Carta>();
        List<Carta> Mao1 = new List<Carta>();
        List<Carta> Mao2 = new List<Carta>();
        Label cartaRDeck1 = new Label();

        public BatalhaForm(string nomeDeck1, string nomeDeck2)
        {
            InitializeComponent();

            foreach (Control cell in tblLayoutPanelOrganizarTela.Controls)
            {
                cell.AllowDrop = true;

                cell.DragEnter += FlowLayoutPanel_DragEnter;
            }

            this.WindowState = FormWindowState.Maximized;

            picBxCarta.BackColor = Color.Transparent;
            lblDesc.Text = "";

            Deck1 = repoDeck.TrazerCartas(nomeDeck1);
            Deck2 = repoDeck.TrazerCartas(nomeDeck2);

            Mao1 = repoBatalha.DrawInicio(Deck1);
            Mao2 = repoBatalha.DrawInicio(Deck2);

            foreach (Carta carta in Mao1)
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

                flwLayoutPanelCartasJgdr1.Controls.Add(novaCarta);

                novaCarta.Click += carta_Click;
                novaCarta.MouseDown += carta_Segurar;
            }
            foreach (Carta carta in Mao2)
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

                flwLayoutPanelCartasJgdr2.Controls.Add(novaCarta);

                novaCarta.Click += carta_Click;
                novaCarta.MouseDown += carta_Segurar;
            }

            CentralizarCartas(flwLayoutPanelCartasJgdr1);
            CentralizarCartas(flwLayoutPanelCartasJgdr2);

            repoBatalha.TurnoMudou(turno, tblLayoutPanelMonstroJgdr1, tblLayoutPanelMonstroJgdr2, flwLayoutPanelCartasJgdr1, flwLayoutPanelCartasJgdr2, carta_Segurar, lblTurnoJogador, picBxPassar);

            Label lbl = new Label();
            lbl.Text = "Passar";
            lbl.ForeColor = Color.Black;
            lbl.AutoSize = true;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.None;
            lbl.Width = 100;
            lbl.Height = 30;
            lbl.Anchor = AnchorStyles.Top;
            lbl.Click += picBxPassar_Click;

            picBxPassar.Controls.Add(lbl);

            picBxPassar.Resize += (s, e) =>
            {
                lbl.Padding = new Padding(picBxPassar.Width / 16, picBxPassar.Height / 4, 0, 0);
                /*lbl.Location = new Point(
                    (picBxPassar.Width - lbl.Width) / 2,
                    (picBxPassar.Height - lbl.Height) / 2
                );*/
            };

            Label lbl2 = new Label();
            lbl2.Text = "Batalha";
            lbl2.ForeColor = Color.Black;
            lbl2.AutoSize = true;
            lbl2.TextAlign = ContentAlignment.MiddleCenter;
            lbl2.Dock = DockStyle.None;
            lbl2.Width = 150;
            lbl2.Height = 40;
            lbl2.Anchor = AnchorStyles.Top;
            lbl2.Click += picBxFase_Click;

            picBxFase.Controls.Add(lbl2);

            picBxFase.Resize += (s, e) =>
            {
                lbl2.Padding = new Padding(picBxFase.Width / 16, picBxFase.Height / 4, 0, 0);
                /*lbl.Location = new Point(
                    (picBxPassar.Width - lbl.Width) / 2,
                    (picBxPassar.Height - lbl.Height) / 2
                );*/
            };

            cartaRDeck1.Text = Convert.ToString(Deck1.Count);
            cartaRDeck1.ForeColor = Color.White;
            /*Label cartaRDeck2 = new Label();
            cartaRDeck2.Text = Convert.ToString(Deck2.Count);*/

            picBxDeckJgdr1.Controls.Add(cartaRDeck1);
            cartaRDeck1.BringToFront();

            /*picBxDeckJgdr1.Resize += (s, e) =>
            {
                cartaRDeck1.Padding = new Padding(picBxDeckJgdr1.Width / 2, picBxDeckJgdr1.Height / 2, 0, 0);
                cartaRDeck1.BringToFront();
            };*/


            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

        }

        private void Lbl2_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void carta_Click(object sender, EventArgs e)
        {
            Carta cartaQueDisparouOEvento = (Carta)sender;

            string[] partes = cartaQueDisparouOEvento.Efeito.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string primeiraParte = partes[0];
            string segundaParte = partes.Length > 1 ? partes[1] : string.Empty;

            picBxCarta.BackgroundImage = null;
            picBxCarta.Image = cartaQueDisparouOEvento.Image;
            picBxCarta.SizeMode = PictureBoxSizeMode.StretchImage;
            picBxCarta.Visible = true;
            picBxCarta.Padding = new Padding(picBxCarta.Width / 10, 0, picBxCarta.Width / 10, 0);
            lblDesc.Text = $"{primeiraParte}\nNome: {cartaQueDisparouOEvento.Nome}\nPoder: {cartaQueDisparouOEvento.Atk}\nDef: {cartaQueDisparouOEvento.Def}\nClasse: {cartaQueDisparouOEvento.Classe}\n{segundaParte}";

            flwLayoutPanelDesc.HorizontalScroll.Enabled = false;
            flwLayoutPanelDesc.HorizontalScroll.Visible = false;
            flwLayoutPanelDesc.VerticalScroll.Enabled = false;
            flwLayoutPanelDesc.VerticalScroll.Visible = false;

            flwLytPnlMonstro_MouseClick(cartaQueDisparouOEvento.Parent, null);

        }

        private void carta_Segurar(object sender, EventArgs e)
        {
            Carta carta = (Carta)sender;

            string[] partes = carta.Efeito.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string primeiraParte = partes[0];
            string segundaParte = partes.Length > 1 ? partes[1] : string.Empty;

            picBxCarta.BackgroundImage = null;
            picBxCarta.Image = carta.Image;
            picBxCarta.SizeMode = PictureBoxSizeMode.StretchImage;
            picBxCarta.Visible = true;
            picBxCarta.Padding = new Padding(picBxCarta.Width / 10, 0, picBxCarta.Width / 10, 0);
            lblDesc.Text = $"{primeiraParte}\nNome: {carta.Nome}\nPoder: {carta.Atk}\nDef: {carta.Def}\nClasse: {carta.Classe}\n{segundaParte}";

            flwLayoutPanelDesc.HorizontalScroll.Enabled = false;
            flwLayoutPanelDesc.HorizontalScroll.Visible = false;
            flwLayoutPanelDesc.VerticalScroll.Enabled = false;
            flwLayoutPanelDesc.VerticalScroll.Visible = false;

            DoDragDrop(carta, DragDropEffects.Move);

        }

        private void CentralizarCartas(FlowLayoutPanel panel)
        {
            if (panel.Controls.Count == 0) return;

            int totalWidth = 0;
            foreach (Control c in panel.Controls)
                totalWidth += c.Width + c.Margin.Horizontal;

            // Espaço vazio que sobra
            int espacoSobrando = panel.ClientSize.Width - totalWidth;

            if (espacoSobrando > 0)
                panel.Padding = new Padding(espacoSobrando / 2, 0, 0, 0); // centraliza
            else
                panel.Padding = new Padding(0);
        }

        private void BatalhaForm_Resize(object sender, EventArgs e)
        {
            foreach (FlowLayoutPanel picBxMonstro in tblLayoutPanelMonstroJgdr1.Controls)
            {
                picBxMonstro.Margin = new Padding(picBxMonstro.Width / 10, 0, picBxMonstro.Width / 10, 0);
            }
            foreach (FlowLayoutPanel picBxMonstro in tblLayoutPanelMonstroJgdr2.Controls)
            {
                picBxMonstro.Margin = new Padding(picBxMonstro.Width / 10, 0, picBxMonstro.Width / 10, 0);
            }

            for (int i = 1; i <= 2; i++)
            {
                FlowLayoutPanel flwPanel;
                TableLayoutPanel tblPanel;

                if (i == 1)
                    flwPanel = flwLayoutPanelCartasJgdr1;
                else
                    flwPanel = flwLayoutPanelCartasJgdr2;

                foreach (Control ctrl in flwPanel.Controls)
                {
                    // Calcula a proporção original da carta
                    float proporcao = (float)ctrl.Width / ctrl.Height;

                    // Nova altura = altura do painel (com margem para não colar)
                    int novaAltura = flwPanel.ClientSize.Height - 20;
                    if (novaAltura <= 0) continue;

                    // Ajusta largura pela proporção
                    int novaLargura = (int)(novaAltura * proporcao);

                    ctrl.Size = new Size(novaLargura, novaAltura);
                }

                if (i == 1)
                    tblPanel = tblLayoutPanelMonstroJgdr1;
                else
                    tblPanel = tblLayoutPanelMonstroJgdr2;

                foreach (FlowLayoutPanel panel in tblPanel.Controls)
                {
                    if (panel.Controls.Count > 0)
                    {
                        Control carta = panel.Controls[0];

                        float proporcao = (float)carta.Width / carta.Height;

                        int novaAltura = panel.ClientSize.Height;

                        int novaLargura = (int)(novaAltura * proporcao);

                        carta.Size = new Size(novaLargura, novaAltura);
                    }
                }
            }

            CentralizarCartas(flwLayoutPanelCartasJgdr1);
            CentralizarCartas(flwLayoutPanelCartasJgdr2);

            // XXX

        }

        private void FlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
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

        private void FlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Carta)))
            {
                Carta carta = (Carta)e.Data.GetData(typeof(Carta));

                FlowLayoutPanel destino = sender as FlowLayoutPanel;
                FlowLayoutPanel origem = carta.Parent as FlowLayoutPanel;
                int x = 0;
                foreach (FlowLayoutPanel panel in destino.Parent.Controls)
                {
                    if (panel.Controls.Count > 0)
                        x++;
                }

                if (destino != null && origem != null && destino != origem && destino.Controls.Count == 1 && destino != origem.Parent && lblFase.Text == "Fase de Batalha")
                {
                    if (carta.Modo == "Defesa")
                    {
                        MessageBox.Show("Cartas em modo de Defesa não podem atacar.");
                        return;
                    }
                    if (carta.Atacou == true)
                    {
                        MessageBox.Show("Carta já atacou nesse turno");
                        return;
                    }
                    else
                    {
                        repoBatalha.Duelo(carta, (Carta)destino.Controls[0], lblVidaJgdr1, lblVidaJgdr2, ref vidaJgdr1, ref vidaJgdr2, flwLayoutPanelCartasJgdr1, flwLayoutPanelCartasJgdr2, tblLayoutPanelMonstroJgdr1, tblLayoutPanelMonstroJgdr2);
                        MessageBox.Show($"{vidaJgdr1} {vidaJgdr2}");
                        if (vidaJgdr1 <= 0)
                        {
                            MessageBox.Show("Jogador 1 ficou sem PV e perdeu o jogo!");
                            this.Close();
                        }
                        else if (vidaJgdr2 <= 0)
                        {
                            MessageBox.Show("Jogador 2 ficou sem PV e perdeu o jogo!");
                            this.Close();
                        }
                        else if (vidaJgdr1 <= 0 && vidaJgdr2 <= 0)
                        {
                            MessageBox.Show("Ambos jogadores ficaram sem PV e perderam o jogo!");
                            this.Close();
                        }
                        carta.Atacou = true;
                    }
                }
                else if (destino != null && origem != null && destino != origem && x <= 0 && destino != origem.Parent && lblFase.Text == "Fase de Batalha")
                {
                    if (carta.Modo == "Defesa")
                    {
                        MessageBox.Show("Cartas em modo de Defesa não podem atacar.");
                        return;
                    }
                    if (carta.Atacou == true)
                    {
                        MessageBox.Show("Carta já atacou nesse turno");
                        return;
                    }
                    if (carta.Parent.Parent == tblLayoutPanelMonstroJgdr1)
                    {
                        vidaJgdr2 -= carta.Atk;
                        lblVidaJgdr2.Text = $"HP: {vidaJgdr2.ToString()}";
                        if (vidaJgdr2 <= 0)
                        {
                            MessageBox.Show("Jogador 2 ficou sem PV e perdeu o jogo!");
                            this.Close();
                        }
                        carta.Atacou = true;
                    }
                    else
                    {
                        vidaJgdr1 -= carta.Atk;
                        lblVidaJgdr1.Text = $"HP: {vidaJgdr1.ToString()}";
                        if (vidaJgdr1 <= 0)
                        {
                            MessageBox.Show("Jogador 1 ficou sem PV e perdeu o jogo!");
                            this.Close();
                        }
                        carta.Atacou = true;
                    }
                }
                else if (destino != null && origem != null && destino != origem && destino.Controls.Count == 0 && destino != origem.Parent && lblFase.Text != "Fase de Batalha")
                {
                    if (summonFadiga == true)
                    {
                        MessageBox.Show("Já invocou nesse turno.");
                        return;
                    }

                    DialogResult resposta = MessageBox.Show("Deseja invocar em modo de defesa?", "Modo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resposta == DialogResult.Yes)
                    {
                        carta.Modo = "Defesa";
                    }
                    else
                    {
                        carta.Modo = "Ataque";
                    }

                    /*if (carta.Parent == flwLayoutPanelCartasJgdr1)
                        Mao1.Remove(carta);
                    else if (carta.Parent == flwLayoutPanelCartasJgdr2)
                        Mao2.Remove(carta);*/


                    origem.Controls.Remove(carta);
                    destino.Controls.Add(carta);
                    carta.Height = destino.ClientSize.Height - (destino.ClientSize.Height / 20);
                    carta.Width = destino.ClientSize.Width - (destino.ClientSize.Width / 15);
                    destino.BackgroundImage = null;
                    destino.AllowDrop = false;
                    carta.MouseDown -= carta_Segurar;
                    carta.MouseDown -= carta_Segurar;
                    summonFadiga = true;

                }

                CentralizarCartas(origem);

            }

        }

        // BATALHA 
        private void picBxPassar_Click(object sender, EventArgs e)
        {
            Label lbl2 = (Label)picBxFase.Controls[0];
            this.Text = Convert.ToString($"Turno {turno += 1}");
            repoBatalha.TurnoMudou(turno, tblLayoutPanelMonstroJgdr1, tblLayoutPanelMonstroJgdr2, flwLayoutPanelCartasJgdr1, flwLayoutPanelCartasJgdr2, carta_Segurar, lblTurnoJogador, picBxPassar);
            lbl2.Text = "Batalha";
            if (lblTurnoJogador.Text == "Turno do Jogador 1")
            {
                if (Deck1.Count == 0)
                {
                    MessageBox.Show("Jogador 1 ficou sem cartas no deck e perdeu o jogo!");
                    this.Close();
                }
                else
                {
                    summonFadiga = false;
                    foreach (FlowLayoutPanel flwPanel in tblLayoutPanelMonstroJgdr1.Controls)
                    {
                        foreach (Carta carta in flwPanel.Controls)
                        {
                            carta.Atacou = false;
                            carta.PosicaoMudou = false;
                        }
                    }
                    Carta cartaDraw = repoBatalha.Draw(Deck1);
                    Carta novaCarta = new Carta
                    {
                        Id_Carta = cartaDraw.Id_Carta,
                        Nome = cartaDraw.Nome,
                        Atk = cartaDraw.Atk,
                        Def = cartaDraw.Def,
                        Classe = cartaDraw.Classe,
                        Efeito = cartaDraw.Efeito,
                        Image = cartaDraw.Image,
                        Size = cartaDraw.Size
                    };
                    flwLayoutPanelCartasJgdr1.Controls.Add(novaCarta);
                    novaCarta.Click += carta_Click;
                    novaCarta.MouseDown += carta_Segurar;
                    BatalhaForm_Resize(sender, e);
                    cartaRDeck1.Text = Convert.ToString(Deck1.Count);
                }
            }
            else
            {
                if (Deck2.Count == 0)
                {
                    MessageBox.Show("Jogador 2 ficou sem cartas no deck e perdeu o jogo!");
                    this.Close();
                }
                else
                {
                    summonFadiga = false;
                    foreach (FlowLayoutPanel flwPanel in tblLayoutPanelMonstroJgdr2.Controls)
                    {
                        foreach (Carta carta in flwPanel.Controls)
                        {
                            carta.Atacou = false;
                            carta.PosicaoMudou = false;
                        }
                    }
                    Carta cartaDraw = repoBatalha.Draw(Deck2);
                    Carta novaCarta = new Carta
                    {
                        Id_Carta = cartaDraw.Id_Carta,
                        Nome = cartaDraw.Nome,
                        Atk = cartaDraw.Atk,
                        Def = cartaDraw.Def,
                        Classe = cartaDraw.Classe,
                        Efeito = cartaDraw.Efeito,
                        Image = cartaDraw.Image,
                        Size = cartaDraw.Size
                    };
                    flwLayoutPanelCartasJgdr2.Controls.Add(novaCarta);
                    novaCarta.Click += carta_Click;
                    novaCarta.MouseDown += carta_Segurar;
                    BatalhaForm_Resize(sender, e);
                }
            }

        }

        private void picBxFase_Click(object sender, EventArgs e)
        {
            Label lbl2 = (Label)picBxFase.Controls[0];
            if (lblFase.Text == "Fase de Batalha")
            {
                lblFase.Text = "Fase Principal 2";
                lbl2.Text = "Passar";
                repoBatalha.FaseMudou(turno, carta_Segurar, lblFase, tblLayoutPanelMonstroJgdr1, tblLayoutPanelMonstroJgdr2, flwLayoutPanelCartasJgdr1, flwLayoutPanelCartasJgdr2);
            }
            else if (lblFase.Text == "Fase Principal 1")
            {
                lblFase.Text = "Fase de Batalha";
                lbl2.Text = "Terminar";
                repoBatalha.FaseMudou(turno, carta_Segurar, lblFase, tblLayoutPanelMonstroJgdr1, tblLayoutPanelMonstroJgdr2, flwLayoutPanelCartasJgdr1, flwLayoutPanelCartasJgdr2);
                picBxPassar.Enabled = false;
            }
            else
            {
                picBxPassar_Click(sender, e);
                lblFase.Text = "Fase Principal 1";
            }

        }

        private void flwLayoutPanelMonstro3Jg1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void flwLytPnlMonstro_MouseClick(object sender, MouseEventArgs e)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel = (FlowLayoutPanel)sender;
            Carta carta = (Carta)panel.Controls[0];
            if (panel.Controls.Count > 0 && lblFase.Text != "Fase de Batalha" && carta.PosicaoMudou == false && carta.Atacou == false)
            { 
                if (carta.Modo != "Defesa")
                {
                    panel.BackColor = Color.Blue;
                    carta.Modo = "Defesa";
                }
                else
                {
                    panel.BackColor = Color.Red;
                    carta.Modo = "Ataque";
                }
                carta.PosicaoMudou = true;
            }
            
        }
    }
}
