using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace YuGiOhTrabalhoWindowsForms
{
    public partial class CadastroForm : Form
    {
        public CadastroForm()
        {
            InitializeComponent();
            lblAviso.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string senha = txtSenha.Text;
            string confirmarSenha = txtConfirmarSenha.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                lblAviso.Text = "! - Preencha todos os campos.";
                return;
            }

            /*if (senha.Length > 11) // Verificar com professor
            {
                lblAviso.Text = "A senha deve ter menos de 12 caracteres.";
                return;
            }*/

            if (senha != confirmarSenha)
            {
                lblAviso.Text = "As senhas não coincidem.";
                return;
            }

            JogadorRepository repo = new JogadorRepository(DbUtil.ConnectionString);
            Jogador novoJogador = new Jogador
            {
                Nome = nome,
                Senha = senha
            };

            try
            {
                int linhas = repo.InserirJogador(novoJogador);
                if (linhas > 0)
                {
                    this.Close();
                }
                else
                {
                    lblAviso.Text = "Erro ao cadastrar.";
                }
            }
            catch (Exception ex)
            {
                lblAviso.Text = "Erro inesperado: " + ex.Message;
            }
        }

        private void CadastroForm_Load(object sender, EventArgs e)
        {

        }
    }
}
