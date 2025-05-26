using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using formulario_exame;

namespace PROJECO_P2_2
{
    public partial class F_principal : Form
    {
        public F_principal()
        {
            InitializeComponent();
        }

        private void BN_enu_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTN_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//pesquisa e comenta a funcao depois faz foto e manda no grupo
        }

        private void BTN_fechar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tens a certeza que tu ques fechar a aplicação?", "sair", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);//temos ue criar uma condicao para quando o ususario clicar em cancelar nao feche
            Application.Exit();//fechar a aplicacao
           
           }
        private void BTTN_max_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BTTN_max.Visible = true;//pesquisa e comenta a funcao depois faz foto e manda no grupo
            BTTN_max.Visible = false;



        }

        private void BTN_rest_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BTN_rest.Visible = true;//pesquisa e comenta a funcao depois faz foto e manda no grupo
            BTN_rest.Visible = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();//tem que chamar o formulario de login na minha opniao
        }

        private void Menu_v_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prova1_matematica_ Forulario = new Prova1_matematica_();
            Forulario.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_datas formularo = new F_datas();
            formularo.Show();
        }

        private void BYN_perfil_Click(object sender, EventArgs e)
        {
         F_perfil formularo = new F_perfil();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            F_perfil formularo = new F_perfil();
            formularo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_sobre formularo = new F_sobre();
            formularo.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            F_sobre formularo = new F_sobre();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            F_datas formularo = new F_datas();
            formularo.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            F_datas formularo = new F_datas();
            formularo.Show();
        }
    }
}
