using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //Acochambramento

namespace YuGiOhTrabalhoWindowsForms.Util
{
    internal static class DbUtil
    {
        public static string ConnectionString { get; } = "server=localhost;database=tcccarta;uid=root;pwd=;";
        //public static string ConnectionString { get; } = "server=br60.hostgator.com.br;database=joaola59_yugioh;uid=joaola59_usu_yugioh;pwd=TP!&T#3,z2dB";

        public static int BuscarIdJogador(string nome)
        {
            int id = -1;
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT id_jogador FROM jogador WHERE nome = @Nome";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        id = Convert.ToInt32(result);
                    }
                }
            }
            return id;
        }

    }
}
