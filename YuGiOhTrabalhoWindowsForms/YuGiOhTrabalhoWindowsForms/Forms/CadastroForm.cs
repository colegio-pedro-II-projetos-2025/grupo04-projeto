using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOhTrabalhoWindowsForms.Entidade;
using YuGiOhTrabalhoWindowsForms.Util;
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

            if (nome.Length > 20)
            {
                lblAviso.Text = "! - Nome tem mais que 20 caracteres.";
                return;
            }


            if (senha != confirmarSenha)
            {
                lblAviso.Text = "! - As senhas não coincidem.";
                return;
            }

            JogadorRepository repo = new JogadorRepository(DbUtil.ConnectionString); //*
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
                    if (linhas == -2)
                    {
                        lblAviso.Text = "! - Nome de usuário já existe.";
                    }
                    else
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
