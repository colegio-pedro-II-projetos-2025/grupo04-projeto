using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOhTrabalhoWindowsForms.Entidade;
using YuGiOhTrabalhoWindowsForms.Properties;
using YuGiOhTrabalhoWindowsForms.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace YuGiOhTrabalhoWindowsForms.Repositorio
{
    internal class BatalhaRepository
    {
        private readonly string _connectionString;

        public BatalhaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Carta> DrawInicio(List<Carta> Deck)
        {
            List<Carta> cartas = new List<Carta>();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                int index = rand.Next(Deck.Count);
                cartas.Add(Deck[index]);
                Deck.RemoveAt(index);
            }
            return cartas;

        }

        public List<Carta> Draw(List<Carta> Deck, List<Carta> Mao)
        {
            Random rand = new Random();
            int index = rand.Next(Deck.Count);
            Mao.Add(Deck[index]);
            Deck.RemoveAt(index);
            return Mao;
        }
        public Carta Draw(List<Carta> Deck)
        {
            Carta carta;
            Random rand = new Random();
            int index = rand.Next(Deck.Count);
            carta = Deck[index];
            Deck.RemoveAt(index);
            return carta;
        }

        /*public void SalvarBatalha(int idJogador1, int idJogador2, int vencedorId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO batalha (id_jogador1, id_jogador2, vencedor_id, data_hora) VALUES (@IdJogador1, @IdJogador2, @VencedorId, @DataHora)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdJogador1", idJogador1);
                    command.Parameters.AddWithValue("@IdJogador2", idJogador2);
                    command.Parameters.AddWithValue("@VencedorId", vencedorId);
                    command.Parameters.AddWithValue("@DataHora", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }*/

        public void TurnoMudou(int turno, TableLayoutPanel tblLayoutPanelMonstroJgdr1, TableLayoutPanel tblLayoutPanelMonstroJgdr2, FlowLayoutPanel flwLayoutPanelCartasJgdr1, FlowLayoutPanel flwLayoutPanelCartasJgdr2, MouseEventHandler carta_Segurar, Label lblJogador, PictureBox picBxPassar)
        {
            {
                bool turnoJogador1 = turno % 2 != 0; // Ímpar = Jogador 1

                picBxPassar.Enabled = true;

                // Função auxiliar para (des)ativar o jogador
                void ConfigurarJogador(
                    TableLayoutPanel tblPanel,
                    FlowLayoutPanel flwPanel,
                    bool habilitar)
                {
                    // Permite ou bloqueia o Drop
                    foreach (FlowLayoutPanel panel in tblPanel.Controls)
                    {
                        panel.AllowDrop = habilitar;
                    }

                    // Ativa ou desativa os eventos de MouseDown nas cartas
                    foreach (Carta carta in flwPanel.Controls)
                    {
                        if (habilitar)
                            carta.MouseDown += carta_Segurar;
                        else
                            carta.MouseDown -= carta_Segurar;
                    }
                }

                // Alterna conforme o turno
                if (turnoJogador1)
                {
                    // Habilita jogador 1, desabilita jogador 2
                    if (turno != 1)
                    {
                        ConfigurarJogador(tblLayoutPanelMonstroJgdr1, flwLayoutPanelCartasJgdr1, true);
                    }
                    ConfigurarJogador(tblLayoutPanelMonstroJgdr2, flwLayoutPanelCartasJgdr2, false);
                    lblJogador.Text = "Turno do Jogador 1";
                }
                else
                {
                    // Habilita jogador 2, desabilita jogador 1
                    ConfigurarJogador(tblLayoutPanelMonstroJgdr1, flwLayoutPanelCartasJgdr1, false);
                    ConfigurarJogador(tblLayoutPanelMonstroJgdr2, flwLayoutPanelCartasJgdr2, true);
                    lblJogador.Text = "Turno do Jogador 2";
                }
            }
        }

        public void FaseMudou(int turno, MouseEventHandler carta_Segurar, Label lblFase, TableLayoutPanel tblLayoutPanelMonstroJgdr1, TableLayoutPanel tblLayoutPanelMonstroJgdr2, FlowLayoutPanel flwLayoutPanelCartasJgdr1, FlowLayoutPanel flwLayoutPanelCartasJgdr2)
        {
            bool turnoJogador1 = turno % 2 != 0;

            if (lblFase.Text == "Fase de Batalha")
            {
                FlowLayoutPanel panel;
                TableLayoutPanel tblPanel;
                TableLayoutPanel tblPanelOposto;
                if (turnoJogador1)
                {
                    panel = flwLayoutPanelCartasJgdr1;
                }
                else
                {
                    panel = flwLayoutPanelCartasJgdr2;
                }
                foreach (Carta carta in panel.Controls)
                {
                    if (!carta.Efeito.Contains("Magia Rápida:"))
                    {
                        // Adicionar ao if caso outro tipo de carta possa ser usado
                        carta.MouseDown -= carta_Segurar;
                    }
                }
                if (turnoJogador1)
                {
                    tblPanel = tblLayoutPanelMonstroJgdr1;
                    tblPanelOposto = tblLayoutPanelMonstroJgdr2;
                }
                else
                {
                    tblPanel = tblLayoutPanelMonstroJgdr2;
                    tblPanelOposto = tblLayoutPanelMonstroJgdr1;
                }
                if (turno != 1)
                {
                    foreach (FlowLayoutPanel flwPanel in tblPanel.Controls)
                    {
                        foreach (Carta carta in flwPanel.Controls)
                        {
                            carta.MouseDown += carta_Segurar;
                        }
                    }
                    foreach (FlowLayoutPanel flwPanel in tblPanelOposto.Controls)
                    {
                        flwPanel.AllowDrop = true;
                    }
                }
            }
            else
            {
                FlowLayoutPanel panel;
                TableLayoutPanel tblPanel;
                TableLayoutPanel tblPanelOposto;
                if (turnoJogador1)
                {
                    panel = flwLayoutPanelCartasJgdr1;
                }
                else
                {
                    panel = flwLayoutPanelCartasJgdr2;
                }
                foreach (Carta carta in panel.Controls)
                {
                    if (!carta.Efeito.Contains("Magia Rápida:"))
                    {
                        carta.MouseDown += carta_Segurar;
                    }
                }
                if (turnoJogador1)
                {
                    tblPanel = tblLayoutPanelMonstroJgdr1;
                    tblPanelOposto = tblLayoutPanelMonstroJgdr2;
                }
                else
                {
                    tblPanel = tblLayoutPanelMonstroJgdr2;
                    tblPanelOposto = tblLayoutPanelMonstroJgdr1;
                }
                if (turno != 1)
                {
                    foreach (FlowLayoutPanel flwPanel in tblPanel.Controls)
                    {
                        foreach (Carta carta in flwPanel.Controls)
                        {
                            carta.MouseDown -= carta_Segurar;
                        }
                    }
                    foreach (FlowLayoutPanel flwPanel in tblPanelOposto.Controls)
                    {
                        flwPanel.AllowDrop = false;
                    }
                }

            }

        }

        public void Duelo(Carta cartaAtacante, Carta cartaDefensor, Label lblVidaJgdr1, Label lblVidaJgdr2, ref int vidaJgdr1, ref int vidaJgdr2, FlowLayoutPanel flwLayoutPanelCartasJgdr1, FlowLayoutPanel flwLayoutPanelCartasJgdr2, TableLayoutPanel tblLayoutPanelMonstroJgdr1, TableLayoutPanel tblLayoutPanelMonstroJgdr2)
        {
            // Verifica se a carta defensora está em modo de defesa ou ataque
            bool defensorEmModoDefesa = cartaDefensor.Modo == "Defesa";

            if (defensorEmModoDefesa)
            {
                // Carta defensora em modo de defesa
                if (cartaAtacante.Atk > cartaDefensor.Def)
                {
                    // Atacante vence
                    MessageBox.Show($"A carta {cartaAtacante.Nome} destruiu a carta {cartaDefensor.Nome} em modo de defesa.");
                    // Remove a carta defensora do campo
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr1.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            panel.Controls.Remove(cartaDefensor);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                    }
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr2.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            panel.Controls.Remove(cartaDefensor);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
                else if (cartaAtacante.Atk < cartaDefensor.Def)
                {
                    // Defensor vence
                    MessageBox.Show($"A carta {cartaAtacante.Nome} atacou a carta {cartaDefensor.Nome} em modo de defesa, mas não conseguiu destruí-la.");

                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr1.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            vidaJgdr2 -= (cartaDefensor.Def - cartaAtacante.Atk);
                            lblVidaJgdr2.Text = $"HP: {vidaJgdr2.ToString()}";

                        }
                    }
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr2.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            vidaJgdr1 -= (cartaDefensor.Def - cartaAtacante.Atk);
                            lblVidaJgdr1.Text = $"HP: {vidaJgdr1.ToString()}";
                        }
                    }
                }
                else
                {
                    // Empate
                    MessageBox.Show($"A carta {cartaAtacante.Nome} atacou a carta {cartaDefensor.Nome} em modo de defesa. Ambas as cartas permanecem no campo.");
                    // Nenhuma carta é destruída
                }
            }
            else
            {
                // Carta defensora em modo de ataque
                if (cartaAtacante.Atk > cartaDefensor.Atk)
                {
                    // Atacante vence
                    MessageBox.Show($"A carta {cartaAtacante.Nome} destruiu a carta {cartaDefensor.Nome} em modo de ataque.");
                    // Reduz a vida do jogador defensor
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr1.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            vidaJgdr1 -= (cartaAtacante.Atk - cartaDefensor.Atk);
                            lblVidaJgdr1.Text = $"HP: {vidaJgdr1.ToString()}";
                        }
                    }
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr2.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            vidaJgdr2 -= (cartaAtacante.Atk - cartaDefensor.Atk);
                            lblVidaJgdr2.Text = $"HP: {vidaJgdr2.ToString()}";

                        }
                    }
                    // Remove a carta defensora do campo
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr1.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            panel.Controls.Remove(cartaDefensor);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                    }
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr2.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            panel.Controls.Remove(cartaDefensor);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
                else if (cartaAtacante.Atk < cartaDefensor.Atk)
                {
                    // Defensor vence
                    MessageBox.Show($"A carta {cartaAtacante.Nome} foi destruída pela carta {cartaDefensor.Nome} em modo de ataque.");
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr1.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            vidaJgdr2 -= (cartaDefensor.Atk - cartaAtacante.Atk);
                            lblVidaJgdr2.Text = $"HP: {vidaJgdr2.ToString()}";
                        }
                    }
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr2.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            vidaJgdr1 -= (cartaDefensor.Atk - cartaAtacante.Atk);
                            lblVidaJgdr1.Text = $"HP: {vidaJgdr1.ToString()}";

                        }
                    }
                    // Remove a carta atacante do campo
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr1.Controls)
                    {
                        if (panel.Controls.Contains(cartaAtacante))
                        {
                            panel.Controls.Remove(cartaAtacante);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                    }
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr2.Controls)
                    {
                        if (panel.Controls.Contains(cartaAtacante))
                        {
                            panel.Controls.Remove(cartaAtacante);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
                else
                {
                    // Empate
                    MessageBox.Show($"A carta {cartaAtacante.Nome} e a carta {cartaDefensor.Nome} se destruíram mutuamente em modo de ataque.");
                    // Remove ambas as cartas do campo
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr1.Controls)
                    {
                        if (panel.Controls.Contains(cartaAtacante))
                        {
                            panel.Controls.Remove(cartaAtacante);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            panel.Controls.Remove(cartaDefensor);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                    }
                    foreach (FlowLayoutPanel panel in tblLayoutPanelMonstroJgdr2.Controls)
                    {
                        if (panel.Controls.Contains(cartaDefensor))
                        {
                            panel.Controls.Remove(cartaDefensor);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                        if (panel.Controls.Contains(cartaAtacante))
                        {
                            panel.Controls.Remove(cartaAtacante);
                            panel.BackgroundImage = Resources.pngtree_gray_creative_border2_removebg_preview;
                            panel.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }
        }
    }
}
