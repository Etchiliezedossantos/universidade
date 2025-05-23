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
    public partial class Prova1_matematica_ : Form
    {
        public Prova1_matematica_()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Prova1_matematica__Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prova2__matematica forulario = new Prova2__matematica();
            forulario.Show();
        }
    }
}
