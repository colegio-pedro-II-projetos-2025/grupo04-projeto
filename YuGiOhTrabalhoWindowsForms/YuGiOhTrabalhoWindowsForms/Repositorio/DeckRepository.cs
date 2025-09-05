using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using YuGiOhTrabalhoWindowsForms.Entidade;
using YuGiOhTrabalhoWindowsForms.Util;

namespace YuGiOhTrabalhoWindowsForms.Repositorio
{
    internal class DeckRepository
    {
        private readonly string _connectionString;

        public DeckRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> BuscarDecks(string nome)
        {
            List<string> decks = new List<string>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT nome_deck FROM deck GROUP BY nome_deck";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        decks.Add(reader.GetString("nome_deck"));
                    }
                }
            }
            return decks;
        }

        public List<string> BuscarDecksPorJogador(string nome)
        {
            List<string> decks = new List<string>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT nome_deck FROM deck, jogador WHERE deck.id_jogador = jogador.id_jogador AND nome = @Nome GROUP BY nome_deck";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decks.Add(reader.GetString("nome_deck"));
                        }
                    }
                }
            }
            return decks;
        }

        public List<Carta> TrazerCartas(string nome_deck)
        {
            List<Carta> cartas = new List<Carta>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT c.id_carta, c.nome, atk, def, frente, classe, quantidade, efeito, limite, raridade FROM deck d, carta c WHERE d.id_carta = c.id_carta AND nome_deck = @Nome";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome_deck);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Carta carta = new Carta
                            {
                                Id_Carta = reader.GetInt32("id_carta"),
                                Nome = reader.GetString("nome"),
                                Atk = reader.GetInt32("atk"),
                                Def = reader.GetInt32("def"),
                                Frente = imgUtil.ConverterBytesParaImagem(reader["frente"] as byte[]),
                                Classe = reader.GetString("classe"),
                                Efeito = reader.GetString("efeito"),
                                Limite = reader.GetInt32("limite"),
                                Raridade = reader.GetString("raridade"),
                                Image = imgUtil.ConverterBytesParaImagem(reader["frente"] as byte[])
                            };



                            int quantidade = reader.GetInt32("quantidade");

                            for (int i = 0; i < quantidade; i++)
                            {
                                cartas.Add(carta);
                            }

                        }
                    }
                }
            }
            return cartas;

        }

        public void RemoverCartaDeck(int id_carta, int quantidade, string nome_deck, int id_jogador)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                if (quantidade > 1)
                {
                    string query = "UPDATE deck SET quantidade = quantidade - 1 WHERE id_carta = @Id_Carta AND nome_deck = @Nome_Deck AND id_jogador = @Id_Jogador";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_Carta", id_carta);
                        command.Parameters.AddWithValue("@Nome_Deck", nome_deck);
                        command.Parameters.AddWithValue("@Id_Jogador", id_jogador);

                        command.ExecuteNonQuery();

                    }
                }
                else
                {
                    string query = "DELETE FROM deck WHERE id_carta = @Id_Carta AND nome_deck = @Nome_Deck AND id_jogador = @Id_Jogador";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_Carta", id_carta);
                        command.Parameters.AddWithValue("@Nome_Deck", nome_deck);
                        command.Parameters.AddWithValue("@Id_Jogador", id_jogador);

                        command.ExecuteNonQuery();

                    }
                }

            }

        }

        public void InserirCartaDeck(string nome_deck, int id_jogador, int id_carta, int quantidade)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                if (quantidade > 0)
                {
                    string query = "UPDATE deck SET quantidade = quantidade + 1 WHERE id_carta = @Id_Carta AND nome_deck = @Nome_Deck AND id_jogador = @Id_Jogador";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_Carta", id_carta);
                        command.Parameters.AddWithValue("@Nome_Deck", nome_deck);
                        command.Parameters.AddWithValue("@Id_Jogador", id_jogador);

                        command.ExecuteNonQuery();

                    }
                }
                else
                {
                    string query = "INSERT INTO deck (nome_deck, id_jogador, id_carta, quantidade) VALUES (@Nome_Deck, @Id_Jogador, @Id_Carta, 1)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome_Deck", nome_deck);
                        command.Parameters.AddWithValue("@Id_Jogador", id_jogador);
                        command.Parameters.AddWithValue("@Id_Carta", id_carta);

                        command.ExecuteNonQuery();

                    }
                }
                
            }

        }

        public bool ValidarDeck(string nome_deck, int id_jogador)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM deck WHERE nome_deck = @Nome AND id_jogador = @Id_Jogador";
                using (var checkCommand = new MySqlCommand(query, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Nome", nome_deck);
                    checkCommand.Parameters.AddWithValue("@Id_Jogador", id_jogador);

                    long count = (long)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        return true; // Nome já existe
                    }
                    else
                    {
                        return false; // Nome não existe
                    }
                }

            }

        }

        public int CriarDeck(string nome_deck, int id_jogador, List<Carta> cartas)
        {
            int linhasAfetadas = 0;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                foreach(Carta carta in cartas)
                {
                    string queryChecar = "SELECT COUNT(*) FROM deck WHERE nome_deck = @Nome AND id_jogador = @Id_Jogador AND id_carta = @Id_Carta";
                    using (var checkCommand = new MySqlCommand(queryChecar, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Nome", nome_deck);
                        checkCommand.Parameters.AddWithValue("@Id_Jogador", id_jogador);
                        checkCommand.Parameters.AddWithValue("@Id_Carta", carta.Id_Carta);

                        long count = (long)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            string query = "UPDATE deck SET quantidade = quantidade + 1 WHERE nome_deck = @Nome AND id_jogador = @Id_Jogador AND id_carta = @Id_Carta";
                            using (var command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Nome", nome_deck);
                                command.Parameters.AddWithValue("@Id_Jogador", id_jogador);
                                command.Parameters.AddWithValue("@Id_Carta", carta.Id_Carta);
                                linhasAfetadas = linhasAfetadas + command.ExecuteNonQuery();

                            }
                        }
                        else
                        {
                            string query = "INSERT INTO deck (nome_deck, id_jogador, id_carta, quantidade) VALUES (@Nome, @Id_Jogador, @Id_Carta, 1)";
                            using (var command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Nome", nome_deck);
                                command.Parameters.AddWithValue("@Id_Jogador", id_jogador);
                                command.Parameters.AddWithValue("@Id_Carta", carta.Id_Carta);
                                linhasAfetadas = linhasAfetadas + command.ExecuteNonQuery();

                            }
                        }
                    }
                }

            }
            return linhasAfetadas;

        }

    }
}
