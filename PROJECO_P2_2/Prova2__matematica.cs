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
    public partial class Prova2__matematica : Form
    {
        public Prova2__matematica()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prova1_matematica_ formulario = new Prova1_matematica_();
            formulario.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prova_F1 formulario = new Prova_F1();
            formulario.ShowDialog();
        }
    }
}
