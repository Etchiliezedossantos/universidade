using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PROJECO_P2_2
{
    public partial class F_cadastro : Form
    {
        public F_cadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = textBox1.Text.Trim();
                string bi = textBox2.Text.Trim();
                string periodo = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(bi) || string.IsNullOrWhiteSpace(periodo))
                {
                    MessageBox.Show("preencha todos os campos");
                    return;
                }
                //gerar senha com base no nome
                string senha = senhaHelper.GerarSenha(nome);

                Candidato candidato = new Candidato
                {
                    NomeCompleto = nome,
                    NumeroBI = bi,
                    Periodo = periodo,
                    Senha = senha
                };
                //salvar no banco de dados
                Conexao c = new Conexao();
                using (MySqlConnection conn = c.Abrir())
                {
                    CandidatoRepo repo = new CandidatoRepo(conn);
                    repo.adicionar(candidato);
                }
                MessageBox.Show("cadastro realizado com sucesso a senha é: " + senha);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        public class Candidato
        {
            public string NomeCompleto { get; set; }
            public string NumeroBI { get; set; }
            public string Periodo { get; set; }
            public string Senha { get; set; }
        }

        public class CandidatoRepo
        {
            private readonly MySqlConnection _connection;

            public CandidatoRepo(MySqlConnection connection)
            {
                _connection = connection;
            }

            public void adicionar(Candidato candidato)
            {
                string sql = "INSERT INTO candidatos (NomeCompleto, NumeroBI, Periodo, Senha)" + "Values (@nome, @bi, @periodo, @senha)";

                using (MySqlCommand cmd = new MySqlCommand(sql, _connection))
                {
                    cmd.Parameters.AddWithValue("@nome", candidato.NomeCompleto);
                    cmd.Parameters.AddWithValue("@bi", candidato.NumeroBI);
                    cmd.Parameters.AddWithValue("@periodo", candidato.Periodo);
                    cmd.Parameters.AddWithValue("@senha", candidato.Senha);

                    cmd.ExecuteNonQuery();
                }
            }


        }
        public static class senhaHelper
        {
            public static string GerarSenha(string nome)
            {
                if (string.IsNullOrWhiteSpace(nome))
                {
                    throw new ArgumentException("O nome nao pode estar vazio.");
                }

                string[] partes = nome.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string primeiraLetra = partes[0][0].ToString().ToLower();
                string ultimaLetra = partes[partes.Length - 1][0].ToString().ToLower(); // ^1 significa o último elemento

                return "123456789" + primeiraLetra + ultimaLetra;
            }
        }

        private void F_cadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
