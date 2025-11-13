using System.Diagnostics.Eventing.Reader;
using YuGiOhTrabalhoWindowsForms.Repositorio;
using YuGiOhTrabalhoWindowsForms.Util;
using YuGiOhTrabalhoWindowsForms.Entidade;
using YuGiOhTrabalhoWindowsForms.Forms;

namespace YuGiOhTrabalhoWindowsForms
{
    public partial class MainMenuForm : Form
    {
        JogadorRepository repo;
        DeckRepository repoDeck = new DeckRepository(DbUtil.ConnectionString);

        public MainMenuForm()
        {
            InitializeComponent();
            lblAviso.Text = "";
            lblJgdr.Text = "";
            numericUpDown1.Visible = false;
            cmbBxDecks1.Visible = false;
            lblDeck1.Visible = false;
            cmbBxDecks2.Visible = false;
            lblDeck2.Visible = false;
            repo = new JogadorRepository(DbUtil.ConnectionString);
            btnEntrarJgdr1.Text = "Entrar";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CadastroForm cadastro = new CadastroForm();
            cadastro.ShowDialog();
        }

        private void btnEntrarJgdr1_Click(object sender, EventArgs e)
        {
            string nome;
            if (btnEntrarJgdr1.Text == "Entrar")
            {
                Jogador jogador = new Jogador
                {
                    Nome = textBox1.Text,
                    Senha = textBox2.Text
                };

                nome = repo.Entrar(jogador);
                if (nome != null)
                {
                    textBox1.Text = nome;
                    textBox2.Visible = false;
                    btnEntrarJgdr1.Text = "Sair";
                    textBox1.ReadOnly = true;
                    textBox2.Text = "";
                    label3.Visible = false;
                    cmbBxDecks1.Visible = true;
                    lblDeck1.Visible = true;

                    List<string> decks = repoDeck.BuscarDecksPorJogador(textBox1.Text);

                    for (int i = 0; i < decks.Count; i++)
                    {
                        cmbBxDecks1.Items.Add(decks[i]);
                    }

                    if (btnEntrarJgdr1.Text == "Sair" && btnEntrarJgdr2.Text == "Sair")
                    {
                        lblJgdr.Text = "Jogador:";
                        numericUpDown1.Visible = true;
                    }

                }
                else
                {
                    lblAviso.Text = "Jogador não encontrado";
                }
            }
            else
            {
                btnEntrarJgdr1.Text = "Entrar";
                textBox2.Visible = true;
                textBox1.Text = "";
                label3.Visible = true;
                textBox1.ReadOnly = false;
                lblDeck1.Visible = false;
                cmbBxDecks1.Visible = false;

                lblJgdr.Text = "";
                numericUpDown1.Visible = false;
                cmbBxDecks1.Items.Clear();

            }

        }

        private void btnEntrarJgdr2_Click(object sender, EventArgs e)
        {
            string nome;
            if (btnEntrarJgdr2.Text == "Entrar")
            {
                Jogador jogador = new Jogador
                {
                    Nome = textBox3.Text,
                    Senha = textBox4.Text
                };

                nome = repo.Entrar(jogador);
                if (nome != null)
                {
                    textBox3.Text = nome;
                    textBox4.Visible = false;
                    btnEntrarJgdr2.Text = "Sair";
                    textBox3.ReadOnly = true;
                    textBox4.Text = "";
                    label4.Visible = false;
                    cmbBxDecks2.Visible = true;
                    lblDeck2.Visible = true;

                    List<string> decks = repoDeck.BuscarDecksPorJogador(textBox3.Text);

                    for (int i = 0; i < decks.Count; i++)
                    {
                        cmbBxDecks2.Items.Add(decks[i]);
                    }

                    if (btnEntrarJgdr1.Text == "Sair" && btnEntrarJgdr2.Text == "Sair")
                    {
                        lblJgdr.Text = "Jogador:";
                        numericUpDown1.Visible = true;
                    }
                }
                else
                {
                    lblAviso.Text = "Jogador não encontrado";
                }
            }
            else
            {
                btnEntrarJgdr2.Text = "Entrar";
                textBox4.Visible = true;
                textBox3.Text = "";
                label4.Visible = true;
                textBox3.ReadOnly = false;
                lblDeck2.Visible = false;
                cmbBxDecks2.Visible = false;

                lblJgdr.Text = "";
                numericUpDown1.Visible = false;
                cmbBxDecks2.Items.Clear();

            }

        }

        private void btnDeck_Click(object sender, EventArgs e)
        {
            int jgdr = 0, jgdrSelect = 0;

            string jgdr1 = textBox1.Text, jgdr2 = textBox3.Text;

            if (numericUpDown1.Visible == true) jgdrSelect = Convert.ToInt32(numericUpDown1.Value);

            if (btnEntrarJgdr1.Text == "Entrar" && btnEntrarJgdr2.Text == "Entrar")
            {
                MessageBox.Show("Nenhum Jogador Logado.");
                return;
            }

            else if (btnEntrarJgdr1.Text == "Sair")
                jgdr = 1;
            else if (btnEntrarJgdr2.Text == "Sair")
                jgdr = 2;
            else
                jgdr = 3;

            DeckManager deckManager = new DeckManager(jgdr, jgdr1, jgdr2, jgdrSelect);
            deckManager.ShowDialog();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnEntrarJgdr1.Text == "Entrar" || btnEntrarJgdr2.Text == "Entrar")
            {
                MessageBox.Show("Ambos jogadores devem estar logados.");
                return;
            }

            if (cmbBxDecks1.SelectedItem == null || cmbBxDecks2.SelectedItem == null)
            {
                MessageBox.Show("Ambos jogadores devem selecionar um deck.");
                return;
            }

            string deck1 = cmbBxDecks1.SelectedItem.ToString();
            string deck2 = cmbBxDecks2.SelectedItem.ToString();

            BatalhaForm batalhaForm = new BatalhaForm(deck1, deck2);
            batalhaForm.ShowDialog();

        }
    }
}
