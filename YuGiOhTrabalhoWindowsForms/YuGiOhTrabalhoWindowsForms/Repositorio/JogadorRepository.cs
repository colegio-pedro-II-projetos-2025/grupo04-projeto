using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using YuGiOhTrabalhoWindowsForms.Entidade;

namespace YuGiOhTrabalhoWindowsForms
{
    internal class JogadorRepository
    {
        private readonly string _connectionString;

        public JogadorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InserirJogador(Jogador jogador)
        {
            int linhasAfetadas = -1;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string queryChecar = "SELECT COUNT(*) FROM jogador WHERE nome = @Nome";
                using (var checkCommand = new MySqlCommand(queryChecar, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Nome", jogador.Nome);

                    long count = (long)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        return -2; // Nome já existe
                    }
                }

                string query = "INSERT INTO jogador (nome, senha) VALUES (@Nome, @Senha)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", jogador.Nome);
                    command.Parameters.AddWithValue("@Senha", jogador.Senha);
                    linhasAfetadas = command.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }
        public string Entrar(Jogador jogador)
        {
            string Nome = null;
            string Senha = null; //Nome encontrado
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT nome, senha FROM jogador WHERE nome = @Nome AND senha = @Senha";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", jogador.Nome);
                    command.Parameters.AddWithValue("@Senha", jogador.Senha);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Nome = reader.GetString("nome");
                            Senha = reader.GetString("senha");

                        }
                    }
                }
            }
            return Nome;
        }
    }
}
