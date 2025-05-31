using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PROJECO_P2_2
{
    public static class CalculadorNotas
    {
        public static void CalcularNotaFinal(int candidatoId)
        {
            int totalQuestoes = 0;
            int totalCorretas = 0;

            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=sistema_exames;Uid=root;Pwd=;"))
            {
                conn.Open();

                string sql = @"
                    SELECT r.QuestaoId, r.Resposta, q.RespostaCerta
                    FROM respostascandidato r
                    INNER JOIN questoes q ON r.QuestaoId = q.Id
                    WHERE r.CandidatoId = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", candidatoId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            totalQuestoes++;

                            string respostaDada = reader["Resposta"].ToString().Trim().ToUpper();
                            string respostaCerta = reader["RespostaCerta"].ToString().Trim().ToUpper();

                            if (respostaDada == respostaCerta)
                            {
                                totalCorretas++;
                            }
                        }
                    }
                }

                if (totalQuestoes > 0)
                {
                    float notaFinal = totalCorretas; // cada questão vale 1 ponto

                    string update = "UPDATE candidatos SET NotaFinal = @nota WHERE Id = @id";

                    using (MySqlCommand cmdUpdate = new MySqlCommand(update, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@nota", notaFinal);
                        cmdUpdate.Parameters.AddWithValue("@id", candidatoId);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
