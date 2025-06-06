using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
    }
}
