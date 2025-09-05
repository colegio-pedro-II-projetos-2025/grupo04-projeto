using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOhTrabalhoWindowsForms.Entidade;
using YuGiOhTrabalhoWindowsForms.Util;

namespace YuGiOhTrabalhoWindowsForms.Repositorio
{
    internal class CartaRepository
    {

        private readonly string _connectionString;

        public CartaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Carta> TrazerCartasSummon()
        {
            List<Carta> cartas = new List<Carta>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT c.id_carta, c.nome, atk, def, frente, classe, efeito, limite FROM carta c GROUP BY nome";
                using (var command = new MySqlCommand(query, connection))
                {

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
                                Image = imgUtil.ConverterBytesParaImagem(reader["frente"] as byte[])
                            };

                            cartas.Add(carta);

                        }

                    }

                }

            }
            return cartas;

        }

        public List<Carta> TrazerCartasSummon(string ordenar, string nome, string classe, string efeito, int atkMin, int atkMax, int defMin, int defMax)
        {
            List<Carta> cartas = new List<Carta>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT c.id_carta, c.nome, atk, def, frente, classe, efeito, limite, raridade FROM carta c";
                
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    query += " WHERE c.nome LIKE @Nome";
                }
                
                if (!string.IsNullOrWhiteSpace(classe) && classe != "All")
                {
                    query += (!string.IsNullOrWhiteSpace(nome) ? " AND" : " WHERE") + " c.classe = @Classe";
                }

                if (!string.IsNullOrWhiteSpace(efeito) && efeito != "All")
                {
                    query += (!string.IsNullOrWhiteSpace(nome) || (!string.IsNullOrWhiteSpace(classe) && classe != "All") ? " AND" : " WHERE") + " c.efeito LIKE @Efeito";
                }

                if (atkMin > 0 || atkMax > 0 || defMin > 0 || defMax > 0)
                {
                    query += (!string.IsNullOrWhiteSpace(nome) || (!string.IsNullOrWhiteSpace(classe) && classe != "All") || (!string.IsNullOrWhiteSpace(efeito) && efeito != "All") ? " AND" : " WHERE") + " c.atk BETWEEN @AtkMin AND (CASE WHEN @AtkMax = 0 THEN (SELECT MAX(atk) FROM carta) ELSE @AtkMax END) AND c.def BETWEEN @DefMin AND (CASE WHEN @DefMax = 0 THEN (SELECT MAX(def) FROM carta) ELSE @DefMax END)";
                }

                switch (ordenar)
                {
                    case "Raridade (Maior p/ Menor)":
                        query += " ORDER BY c.raridade DESC";
                        break;
                    case "Raridade (Menor p/ Maior)":
                        query += " ORDER BY c.raridade ASC";
                        break;
                    case "Atk (Maior p/ Menor)":
                        query += " ORDER BY c.atk DESC";
                        break;
                    case "Atk (Menor p/ Maior)":
                        query += " ORDER BY c.atk ASC";
                        break;
                    case "Def (Maior p/ Menor)":
                        query += " ORDER BY c.def DESC";
                        break;
                    case "Def (Menor p/ Maior)":
                        query += " ORDER BY c.def ASC";
                        break;
                    case "Nome (A → Z)":
                        query += " ORDER BY c.nome ASC";
                        break;
                    case "Nome (Z → A)":
                        query += " ORDER BY c.nome DESC";
                        break;
                }

                using (var command = new MySqlCommand(query, connection))
                {

                    if (!string.IsNullOrWhiteSpace(nome))
                    {
                        command.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    }

                    if ((!string.IsNullOrWhiteSpace(classe) && classe != "All"))
                    {
                        command.Parameters.AddWithValue("@Classe", classe);
                    }

                    if ((!string.IsNullOrWhiteSpace(efeito) && efeito != "All"))
                    {
                        command.Parameters.AddWithValue("@Efeito", "%" + efeito + "%");
                    }

                    command.Parameters.AddWithValue("@AtkMin", atkMin > 0 ? atkMin : 0);
                    command.Parameters.AddWithValue("@AtkMax", atkMax > 0 ? atkMax : 0);
                    command.Parameters.AddWithValue("@DefMin", defMin > 0 ? defMin : 0);
                    command.Parameters.AddWithValue("@DefMax", defMax > 0 ? defMax : 0);

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
                                Image = imgUtil.ConverterBytesParaImagem(reader["frente"] as byte[])
                            };

                            cartas.Add(carta);

                        }

                    }

                }
            }

            return cartas;

        }

    }

}
