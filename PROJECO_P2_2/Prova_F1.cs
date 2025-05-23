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
    public partial class Prova_F1 : Form
    {
        public Prova_F1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_PROVAF2 f_PROVAF2 = new F_PROVAF2();
            f_PROVAF2.Show();
        }
    }
}
