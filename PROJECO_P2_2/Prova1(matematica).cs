using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PROJECO_P2_2
{
    public partial class Prova1_matematica_ : Form
    {
        private List<QuestaoExame> questoesMatematica;

        public Prova1_matematica_()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Prova1_matematica__Load(object sender, EventArgs e)
        {
            if (EstadoCandidato() == "finalizado")
            {
                MessageBox.Show("Você já realizou o exame.");
                this.Close();
                return;
            }

            MostrarQuestoes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prova2__matematica forulario = new Prova2__matematica();
            forulario.Show();
        }

        private void Prova1_matematica__FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void panelQestoes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void proximo1_Click(object sender, EventArgs e)
        {
            
             try
             {
                 SalvarRespostas();
                 

                 // Abre o formulário da prova de Física
                 Prova_F1 formFisica = new Prova_F1();
                 formFisica.Show();
                 this.Hide(); // ou this.Close() se quiser fechar o formulário atual
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Erro ao salvar respostas: " + ex.Message);
             }
        }


        //METODOS
        private void MostrarQuestoes()
        {
            List<QuestaoExame> questoes = BuscarQuestoes();
            int posY = 10;

            foreach (var questao in questoes)
            {
                GroupBox gb = new GroupBox();
                gb.Width = 600;
                gb.Height = 130;
                gb.Text = "Questão";
                gb.Tag = questao.Id;
                gb.Top = posY;
                gb.Left = 10;

                Label lbl = new Label();
                lbl.Text = questao.Enunciado;
                lbl.Width = 580;
                lbl.Top = 10;
                lbl.Left = 10;
                lbl.AutoSize = true;
                gb.Controls.Add(lbl);

                int topOpcao = 40;
                char[] letras = { 'A', 'B', 'C', 'D' };
                string[] opcoes = { questao.OpcaoA, questao.OpcaoB, questao.OpcaoC, questao.OpcaoD };

                for (int i = 0; i < 4; i++)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = $"{letras[i]}) {opcoes[i]}";
                    rb.Tag = letras[i].ToString();
                    rb.Top = topOpcao + i * 20;
                    rb.Left = 20;
                    rb.Width = 550;
                    gb.Controls.Add(rb);
                }

                panelQestoes.Controls.Add(gb);
                posY += gb.Height + 10;
            }
        }


        private void SalvarRespostas()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=sistema_exames;Uid=root;Pwd=;"))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (Control ctrl in panelQestoes.Controls)
                        {
                            if (ctrl is GroupBox gb)
                            {
                                int questaoId = (int)gb.Tag;
                                string respostaSelecionada = null;

                                foreach (Control c in gb.Controls)
                                {
                                    if (c is RadioButton rb && rb.Checked)
                                    {
                                        respostaSelecionada = rb.Tag.ToString();
                                        break;
                                    }
                                }

                                if (respostaSelecionada != null)
                                {
                                    string sql = @"
                                INSERT INTO respostascandidato (CandidatoId, QuestaoId, Resposta) 
                                VALUES (@candidato, @questao, @resposta)
                                ON DUPLICATE KEY UPDATE Resposta = @resposta;";

                                    using (MySqlCommand cmd = new MySqlCommand(sql, conn, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@candidato", SessaoUsuario.Id);
                                        cmd.Parameters.AddWithValue("@questao", questaoId);
                                        cmd.Parameters.AddWithValue("@resposta", respostaSelecionada);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;  // relança para o chamador tratar se quiser
                    }
                }
            }
        }





        private List<QuestaoExame> BuscarQuestoes()
        {
            List<QuestaoExame> lista = new List<QuestaoExame>();

            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=sistema_exames;Uid=root;Pwd=;"))
            {
                conn.Open();
                string sql = "SELECT * FROM questoes WHERE disciplina = 'Matematica'";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new QuestaoExame
                            {
                                Id = reader.GetInt32("Id"),
                                Enunciado = reader.GetString("Enunciado"),
                                OpcaoA = reader.GetString("OpcaoA"),
                                OpcaoB = reader.GetString("OpcaoB"),
                                OpcaoC = reader.GetString("OpcaoC"),
                                OpcaoD = reader.GetString("OpcaoD")
                            });
                        }
                    }
                }
            }

            return lista;
        }

         private string EstadoCandidato()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=sistema_exames;Uid=root;Pwd=;"))
            {
                conn.Open();
                string sql = "SELECT Estado FROM candidatos WHERE Id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", SessaoUsuario.Id);
                    object estado = cmd.ExecuteScalar();
                    return estado != null ? estado.ToString() : "";
                }
            }
        }

    }
}
