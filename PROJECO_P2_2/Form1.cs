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
//using formulario_exame;

namespace PROJECO_P2_2
{
    public partial class F_principal : Form
    {
        public F_principal()
        {
            InitializeComponent();
        }

       
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Limpar os dados da sessão
            SessaoUsuario.limpar();

            // Abrir a tela de login novamente
            F_login telaLogin = new F_login();
            telaLogin.Show();

            // Fechar a tela atual
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string estadoCandidato = "";

            try
            {
                Conexao conexaoBD = new Conexao();
                using (MySqlConnection conn = conexaoBD.Abrir())
                {
                    string sql = "SELECT Estado FROM candidatos WHERE Id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", SessaoUsuario.Id);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        estadoCandidato = resultado.ToString();

                        if (estadoCandidato == "Inscrito")
                        {
                            // Permitir iniciar o teste
                            Prova1_matematica_ telaProva = new Prova1_matematica_();
                            telaProva.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Você já realizou o teste. Não é possível fazer novamente.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Candidato não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar estado do candidato: " + ex.Message);
            }



            //Prova1_matematica_ Forulario = new Prova1_matematica_();
            //Forulario.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_datas formularo = new F_datas();
            formularo.Show();
        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            F_perfil formularo = new F_perfil();
            formularo.Show();
        }

        private void Link_perfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_perfil formularo = new F_perfil();
            formularo.Show();
        }

       
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_sobre formularo = new F_sobre();
            formularo.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            F_sobre formularo = new F_sobre();
            formularo.Show();
        }

        private void F_principal_Load(object sender, EventArgs e)
        {

        }

        private void F_principal_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
