using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECO_P2_2
{
    public partial class F_principalFuncionario : Form
    {
        public F_principalFuncionario()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_cadastro formulario = new F_cadastro();
            formulario.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_resultadoT formulario = new F_resultadoT();
            formulario.Show();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void F_principalFuncionario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ao terminar a sessao
            // Limpar os dados da sessão
            SessaoUsuario.limpar();

            // Abrir a tela de login novamente
            F_login telaLogin = new F_login();
            telaLogin.Show();

            // Fechar a tela atual
            this.Close();
        }
    }
}
