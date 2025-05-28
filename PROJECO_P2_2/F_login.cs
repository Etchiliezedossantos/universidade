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
    public partial class F_login : Form
    {
        public F_login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string nome = Nome.Text.Trim();
            string senha = PassWord.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }


            try
            {
                Conexao conexaoBD = new Conexao();
                using (MySqlConnection conn = conexaoBD.Abrir())
                {
                    string sql = "SELECT * FROM candidatos WHERE NomeCompleto = @nome AND Senha = @senha";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            SessaoUsuario.Id = Convert.ToInt32(reader["Id"]);
                            SessaoUsuario.NomeCompleto = reader["NomeCompleto"].ToString();
                            SessaoUsuario.NumeroBI = reader["NumeroBI"].ToString();
                            SessaoUsuario.Periodo = reader["Periodo"].ToString();
                            SessaoUsuario.Senha = reader["Senha"].ToString();



                            //esta e a parte para chamar o formulario de dashboard ou perfil
                            F_principal telaHome = new F_principal();
                            telaHome.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nome ou senha incorretos.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void F_login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void F_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
